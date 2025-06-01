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
    public partial class FlappyDemon : Form
    {
        public FlappyDemon()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width -= 30;

            if (panel1.Width == 0)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel2.Left += 30; panel2.Width -= 30;

            if (panel2.Width == 0)
            {
                timer2.Stop();
            }
        }

        private void FlappyDemon_Load(object sender, EventArgs e)
        {

        }
    }
}
