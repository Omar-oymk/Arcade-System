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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void Profile_MouseEnter(object sender, EventArgs e)
        {
            Profile.ForeColor = Color.White;
        }

        private void Profile_MouseLeave(object sender, EventArgs e)
        {
            Profile.ForeColor = Color.Black;
        }

        private void Games_MouseEnter(object sender, EventArgs e)
        {
            Games.ForeColor = Color.White;
        }

        private void Games_MouseLeave(object sender, EventArgs e)
        {
            Games.ForeColor = Color.Black;    
        }
        
        private void Logout_MouseEnter(object sender, EventArgs e)
        {
            Logout.ForeColor = Color.White;
        }

        private void Logout_MouseLeave(object sender, EventArgs e)
        {
            Logout.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        bool panelIsOpen = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int targetWidth = 300;

            if(!panelIsOpen)
            {
                SideBar.Width += 30;

                if(SideBar.Width == targetWidth)
                {
                    panelIsOpen = true;
                    timer1.Stop();
                }
            }

            else
            {
                SideBar.Width -= 30;

                if (SideBar.Width == 0)
                {
                    timer1.Stop();
                    panelIsOpen = false;
                }
            }
        }

        private void Profile_Click(object sender, EventArgs e)
        {

        }

        private void Games_Click(object sender, EventArgs e)
        {
            FlappyDemon game = new FlappyDemon();
            game.ShowDialog();
        }
    }
}
