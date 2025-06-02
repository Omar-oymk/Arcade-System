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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
            
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

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
            int targetWidth = 270;

            if(!panelIsOpen)
            {
                SideBar.Width += 27;

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
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
            profile.FormClosed += (s, args) => this.Show();
        }

        private void Games_Click(object sender, EventArgs e)
        {
            FlappyDemon game = new FlappyDemon();
            game.ShowDialog();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void SideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }
    }
}
