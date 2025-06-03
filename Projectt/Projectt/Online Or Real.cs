using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectt
{
    public partial class Online_Or_Real : Form
    {
        Player player;
        public Online_Or_Real(Player player)
        {
            InitializeComponent();
            this.player = player;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage(player);
            main.Show();
            this.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            RealLife page = new RealLife();
            page.Show();
            this.Close();
        }
    }
}
