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
    public partial class Online_Or_Real : Form
    {
        Player player;
        SoundPlayer buttonEffect;
        public Online_Or_Real(Player player)
        {
            InitializeComponent();
            this.player = player;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"C:\Users\user\Downloads\Arcade Project\Assets\Music\ButtonClick.wav");
            buttonEffect.Play();
            MainPage main = new MainPage(player);
            main.Show();
            this.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"C:\Users\user\Downloads\Arcade Project\Assets\Music\ButtonClick.wav");
            buttonEffect.Play();
            RealLife page = new RealLife();
            page.Show();
            this.Close();
        }
    }
}
