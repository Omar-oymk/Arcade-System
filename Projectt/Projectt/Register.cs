using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectt
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#6c329d");
            //label3.ForeColor = ColorTranslator.FromHtml("#422991");
            //label4.ForeColor = ColorTranslator.FromHtml("#422991");
        }

        private void Form1_Load(object sender, EventArgs e) { }

        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=SignInArcade;Integrated Security=True;");
        string email;
        int password;
        static void main(string[] args)
        {
            Application.Run(new Login());


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
