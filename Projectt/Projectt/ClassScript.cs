using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Projectt
{
    #region Cards
    interface ICards
    {
        int Points { get; }
        string PrintMessage();
    }

    // kids card
    class KidsCard : ICards 
    {
        public int Points { get; set; }
        public KidsCard()
        {
            Points = 100;
            PrintMessage();
        }

        public string PrintMessage()
        {
            return $"Congrats! You have access to all kids games!\n Points: {Points}";
        }
    }

    // average card
    class AverageCard : ICards
    {
        public int Points { get; set; }
        public AverageCard()
        {
            Points = 200;
            PrintMessage();
        }
        public string PrintMessage()
        {
            return $"Congrats! You have access to 80% of the games!\n Points: {Points}";
        }
    }

    // VIP card
    class VIPCard : ICards
    {
        public int Points { get; set; }
        public VIPCard()
        {
            Points = 350;
            PrintMessage();
        }
         public string PrintMessage()
         {
            return $"Congrats! You have access to all of the games and a free snack!\n Points: {Points}";
         }
    }
    #endregion

    #region Users
    abstract class User
    {
        protected internal string Username;
        protected internal string Email;
        protected internal string Password;
    }

    class Player : User
    {
        private ICards Card;        // composition
        public ICards cards
        {
            get
            {
                return Card;
            }
            set
            {
                Card = cardChoice(Convert.ToString(value));     // TRY
            }
        }

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
        // password at least 8 characters
        // contain at least 1 number, special characters (!,#,$,&,_,?)


        // take string entered 
        // check string == what?
        // based on input (create a new object) (card)
        private ICards cardChoice(string input)
        {
            if (input == "VIP Card")
            {
                return new VIPCard();
            }
            else if (input == "Kids Card")
            {
                return new KidsCard();
            }
            return new AverageCard();
        }
    }

    class Admin : User
    {

        public Admin(string email, string password)
        {
            Email = email;
            Password = password;
            Username = truncateEmail(Email);
        }
        Game AddGame(string name, string modeChoice, int points)
        {
            // composition 
            return new Game(name, modeChoice, points);
        }

        void RemoveGame(Game game)
        {
            game = null;
        }

        void SetGamePrice(Game game, int newPointCost)
        {
            game.Points = newPointCost;
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
    class Game      // exception handling for int values (not less than 0)
    {
        private static int count = 0;
        private string name;
        public int id { get; }
        public int Points { get; set; }
        private IMode mode;

        public Game(string name, string modeChoice, int points)
        {
            id = count;
            count++;
            this.name = name;
            Points = points;
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
    interface IMode
    {
        string mode();
    }

    class SinglePlayer : IMode
    {
        public string mode()
        {
            return "Single Player mode is selected!";
        }
    }
    
    class MultiPlayer : IMode
    {
        public string mode()
        {
            return "Multi-Player mode is selected!";
        }
    }
    #endregion
}