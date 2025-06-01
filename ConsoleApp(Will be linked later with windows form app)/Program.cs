using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Will_be_linked_later_with_windows_forms_app_
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
        protected string Username;
        protected string Email;
        protected string Password;
    }

    class Player : User
    {
        private ICards Card;        // composition
        public Player(string email, string password, string card)
        {
            // check conditions to set el email
            if (validEmail(email))
            {
                Email = email;
                Username = truncateEmail(Email);
            }

            if (validPassword(password))
            {
                Password = password;
            }

            Card = cardChoice(card);
        }

        private bool validEmail(string email)
        {
            String temp = "";
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    for (int j = (i + 1); j < email.Length; j++)
                    {
                        temp += email[i];   // saved whatever is after the @
                    }
                    break;
                }
            }
            // valids: outlook.com, yahoo.com, gmail.com (Outlook.com)
            if (temp.ToLower() == "yahoo.com" ||
                temp.ToLower() == "gmail.com" ||
                temp.ToLower() == "outlook.com")
            {
                return true;
            }

            return false;
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
        private bool validPassword(string password)
        {
            bool valid1 = false;
            bool valid2 = false;
            // first check that length >=8
            int size = password.Length;
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] specialChars = { '!', '#', '$', '&', '_', '?' };
            if (size >= 8)
            {
                for (int i = 0; i < size; i++)
                {
                    foreach (char number in numbers)
                    {
                        if (password[i] == number)
                        {
                            valid1 = true;
                            break;
                        }
                    }
                    foreach (char special in specialChars)
                    {
                        if (password[i] == special)
                        {
                            valid2 = true;
                            break;
                        }
                    }
                }
            }

            if (valid1 && valid2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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