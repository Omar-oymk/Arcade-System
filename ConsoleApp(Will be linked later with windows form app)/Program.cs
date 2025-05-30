using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Will_be_linked_later_with_windows_forms_app_
{
    //displaying balance
    interface Icards
    {
        string points();
    }
    class averageticket : Icards
    {
        public virtual string points()
        {
            return "Congrats! You gained 200 points that provides access to 80% of the games.";
        }
    }
    class KidsSection : averageticket
    {
        public override string points()
        {
            return "Congrats! You have access to all kids games!";
        }
    }
    class VIP : averageticket
    {
        public override string points()
        {
            return "Congrats! You gained 350 points that provides access to all of our games and a free snack!";
        }

    }

    //if else on premises || online
    class singlePlayer
    {
        public virtual string mode()
        {
            return "Single Player mode is selected!";
        }
    }

    class multiplayer : singlePlayer
    {
        public override string mode()
        {
            return "Multi-Player mode is selected!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
