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
    public partial class Ticket : Form
    {
        SoundPlayer background;
        SoundPlayer buttonEffect;

        public Ticket()
        {
            InitializeComponent();
            background = new SoundPlayer(@"C:\Users\user\Downloads\AdhesiveWombat - Night Shade (mp3cut.net).wav");
            background.Play();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"C:\Users\user\Downloads\game-start-6104.wav");
            buttonEffect.Play();

            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Close();
        }
    }
}
