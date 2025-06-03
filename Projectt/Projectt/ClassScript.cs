using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Projectt
{

    #region Cards
    public interface ICards
    {
        string name { get; }
        int Points { get; set; }
        string PrintMessage();
    }

    // kids card
    public class KidsCard : ICards 
    {
        public string name { get; }
        public int Points { get; set; }
        public KidsCard()
        {
            Points = 100;
            name = "Kids Card";
        }

        public string PrintMessage()
        {
            return $"Congrats! You have access to all kids games!\n Points: {Points}";
        }
    }

    // average card
    public class AverageCard : ICards
    {
        public string name { get; set; }
        public int Points { get; set; }
        public AverageCard()
        {
            name = "Average Card";
            Points = 200;
        }
        public string PrintMessage()
        {
            return $"Congrats! You have access to 80% of the games!\n Points: {Points}";
        }
    }

    // VIP card
    public class VIPCard : ICards
    {
        public string name { get; }
        public int Points { get; set; }
        public VIPCard()
        {
            name = "VIP Card";
            Points = 350;
        }
        public string PrintMessage()
         {
            return $"Congrats! You have access to all of the games and a free snack!\n Points: {Points}";
         }
    }
    #endregion

    #region Users
    public abstract class User
    {
        protected internal string Username;
        protected internal string Email;
        protected internal string Password;
    }

    public class Player : User
    {
        public ICards Card { get; set; }
        public Player(string email, string password)
        {
            Email = email;
            Password = password;
            Username = truncateEmail(Email);
        }

        private string truncateEmail(string email)
        {
            string temp = "";
            int i = 0;

            while (email[i] != '@')
            {
                temp += email[i];
                i++;
            }

            return temp;
        }
    }

    public class Admin : User
    {

        public Admin(string email, string password)
        {
            Email = email;
            Password = password;
            Username = truncateEmail(Email);
        }
        public Game AddGame(string name, string modeChoice)
        {
            // composition 
            return new Game(name, modeChoice);
        }

        public void RemoveGame(Game game)
        {
            game = null;
        }

        public void SetGamePrice(string name, int newPointCost)
        {
            // search for the game in the global array of games
            // search with index 
            for(int i = 8; i <= GamesStore.currentIndex + 1; i++)
            {
                if (GamesStore.games[i] != null && GamesStore.games[i].name == name)
                {
                    GamesStore.games[i].Points = newPointCost;
                    MessageBox.Show("Changed Points Successfully");
                    return;
                }
            }
            MessageBox.Show("Game Not Found");
        }



        private string truncateEmail(string email)
        {
            string temp = "";
            int i = 0;

            while (email[i] != '@')
            {
                temp += email[i];
                i++;
            }

            return temp;
        }
    }
    #endregion

    #region Games
    public class Game      // exception handling for int values (not less than 0)
    {
        private static int count = 0;
        public string name { get; }
        public int id { get; }
        public int Points { get; set; }
        public IMode mode { get; }

        public Game(string name, string modeChoice)
        {
            id = count;
            count++;
            this.name = name;
            Points = 30;
            mode = GameMode(modeChoice);
        }

        private IMode GameMode(string input)
        {
            if (input == "Multiplayer")
            {
                return new MultiPlayer();
            }
            else
            {
                return new SinglePlayer();
            }
        }
    }
    public interface IMode
    {
        string Printmode();
    }

    public class SinglePlayer : IMode
    {
        public string Printmode()
        {
            return "Single Player mode is selected!";
        }
    }

    public class MultiPlayer : IMode
    {
        public string Printmode()
        {
            return "Multi-Player mode is selected!";
        }
    }
    #endregion
}