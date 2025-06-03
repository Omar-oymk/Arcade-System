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
        string choice;
        private bool chosenATicket = false;
        SoundPlayer background;
        SoundPlayer buttonEffect;
        Player player;
        public Ticket(Player player)
        {
            InitializeComponent();
            background = new SoundPlayer(@"C:\Users\user\Downloads\Arcade Project\Assets\Music\TicketSong.wav");
            background.Play();
            this.player = player;
        }

        private void Ticket_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenATicket = true;
            choice = comboBox1.SelectedItem.ToString();
        }

        public void chooseCard(string choice)
        {
            //player.card = player.cardChoice(choice);        // assigns ticket
            if (choice == "VIP Card")
            {
                player.Card = new VIPCard();
            }
            else if (choice == "Kids Card")
            {
                player.Card = new KidsCard();
            }
            else
            {
                player.Card = new AverageCard();
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            chooseCard(choice);

            if (chosenATicket)
            {
                buttonEffect = new SoundPlayer(@"C:\Users\user\Downloads\Arcade Project\Assets\Music\ButtonClick.wav");
                buttonEffect.Play();
                MessageBox.Show(player.Card.PrintMessage());

                Online_Or_Real Page = new Online_Or_Real(player);
                Page.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Choose A Ticket");
            }
        }
    }
}
