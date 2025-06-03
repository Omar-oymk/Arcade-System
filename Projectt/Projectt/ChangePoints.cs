using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projectt
{
    public partial class ChangePoints : Form
    {
        Admin admin;
        bool textbox1Changed = false;
        bool textbox2Changed = false;
        public ChangePoints(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textbox1Changed && textbox2Changed) // if the textbox was changed check if the input was a number
            {
                int number;
                if (int.TryParse(textBox2.Text, out number))
                {
                    // now search for the game with name
                    admin.SetGamePrice(textBox1.Text, Convert.ToInt32(textBox2.Text));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in the textbox first.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textbox2Changed = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textbox1Changed = true;
        }
    }
}
