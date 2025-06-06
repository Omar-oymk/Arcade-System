using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectt
{
    public partial class MainPage : Form
    {
        Player player;
        SoundPlayer buttonEffect;
        public MainPage(Player player)
        {
            InitializeComponent();
            this.FormClosed += (s,args) => Application.Exit();
            this.player = player;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            Points.Text = "Points: " + player.Card.Points;

            PictureBox[] hiddenPictureBoxes = new PictureBox[]
            {
                pictureBox15, pictureBox14, pictureBox13, pictureBox12
            };
            Button[] hiddenButtons = new Button[]
            {
                button11, button12, button9, button10
            };

            for (int i = 0; i < ImageStore.images.Length; i++)
            {
                if (ImageStore.images[i] != null)
                {
                    hiddenPictureBoxes[i].Image = ImageStore.images[i];
                    hiddenPictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    hiddenButtons[i].Visible = true;
                    hiddenButtons[i].Enabled = true;
                }
            }
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
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            Profile profile = new Profile(player);
            profile.Show();
            this.Hide();
            profile.FormClosed += (s, args) => this.Show();
        }

        private void Games_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            FlappyDemon game = new FlappyDemon();
            this.Hide();
            game.Show();
            game.FormClosed += (s, args) => this.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            Login login = new Login();
            login.Show();
            this.Hide();
            login.FormClosed += (s, args) => this.Close();
        }

        #region Play Buttons
        private void PlayGame_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= 30)
            {
                player.Card.Points -= 30;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= 30)
            {
                player.Card.Points -= 30;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= 30)
            {
                player.Card.Points -= 30;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= 30)
            {
                player.Card.Points -= 30;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= 30)
            {
                player.Card.Points -= 30;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= 30)
            {
                player.Card.Points -= 30;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= 30)
            {
                player.Card.Points -= 30;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= 30)
            {
                player.Card.Points -= 30;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= GamesStore.games[8].Points)
            {
                player.Card.Points -= GamesStore.games[8].Points;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= GamesStore.games[9].Points)
            {
                player.Card.Points -= GamesStore.games[9].Points;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= GamesStore.games[10].Points)
            {
                player.Card.Points -= GamesStore.games[10].Points;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            if (player.Card.Points >= GamesStore.games[11].Points)
            {
                player.Card.Points -= GamesStore.games[11].Points;
                Points.Text = "Points: " + player.Card.Points;
            }
            else
            {
                MessageBox.Show("Recharge Points To Continue");
            }
        }
        #endregion
    }
}
