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
    public partial class AddGame : Form
    {
        public Image[] images = new Image[]
        {
            Image.FromFile(@"Images\diamond (1).png"),
            Image.FromFile(@"Images\space-invaders.png"),
            Image.FromFile(@"Images\ghost (1).png"),
            Image.FromFile(@"Images\block.png"),
            Image.FromFile(@"Images\tetris.png"),
        };

        Admin admin;
        Game game;
        string modeChoice;
        bool chosenAMode = false;
        Image selectedImage;
        SoundPlayer buttonEffect;
        public AddGame(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenAMode = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
            buttonEffect.Play();
            bool valid1 = false, valid2 = false, valid3 = false;
            // checks for index
            int index;

            if (int.TryParse(textBox2.Text, out index))
            {
                if (index >= 0 && index < images.Length)
                {
                    selectedImage = images[index];
                    valid1 = true;
                }
                else
                {
                    MessageBox.Show("Index out of range.");
                }
            }
            else
            {
                MessageBox.Show("Enter a valid number.");
            }


            if (chosenAMode)
            {
                modeChoice = comboBox1.SelectedItem.ToString();
                valid2 = true;
            }
            else
            {
                MessageBox.Show("Choose The Mode");
            }

            if(valid1 && valid2)
            {
                // for photo
                if (ImageStore.currentIndex < ImageStore.images.Length)
                {

                    valid3 = true;
                }
                else
                {
                    MessageBox.Show("No more space to add games");
                    this.Close();
                }
            }

            if(valid3)
            {
                MessageBox.Show("Game Added Successfully");
                game = admin.AddGame(textBox1.Text, modeChoice);        //  using add game from admin class
                MessageBox.Show(game.mode.Printmode());     // using mode composition from the game
                ImageStore.images[ImageStore.currentIndex] = selectedImage;
                ImageStore.currentIndex++;
                GamesStore.games[GamesStore.currentIndex] = game;
                //MessageBox.Show(Convert.ToString(GamesStore.games[GamesStore.currentIndex].id)); // REMOVE THIS
                GamesStore.currentIndex++;
                this.Close();
            }
        }
    }
}