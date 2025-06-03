using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml.Linq;

namespace Projectt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
    public static class ImageStore
    {
        public static Image[] images = new Image[4];
        public static int currentIndex = 0;
    }
    public static class GamesStore
    {
        public static Game[] games = new Game[12]
        {
            new Game("World of Warcraft", "Singleplayer"),
            new Game("Pokemon Go", "Singleplayer"),
            new Game("Worms 1997", "Singleplayer"),
            new Game("Super Mario", "Singleplayer"),
            new Game("The Sims", "Singleplayer"),
            new Game("Minecraft", "Multiplayer"),
            new Game("Snake", "Singleplayer"),
            new Game("Angry Birds", "Singleplayer"),
            null, null, null, null
        };
        public static int currentIndex = 8;
    }
}
