using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projectt
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e) { }

        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=SignInArcade;Integrated Security=True;");
        string email;
        int password;
        private void buttonLogin_Click(object sender, EventArgs e) 
        {
            try
            {
                string email = txt_Email.Text;
               int password;

                // Convert password input to an integer safely
                if (!int.TryParse(Pswrd_text.Text, out password))
                {
                    MessageBox.Show("Invalid password format! Please enter a number.");
                    return; // Stop execution if the password isn't a valid number
                }

                // Correct SQL query with parameterized values
                string query = "SELECT * FROM dbo.Arcade WHERE Email = @Email AND Password = @Password";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password); // Sending password as an integer

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 DataTable dtablem = new DataTable();
               sda.Fill(dtablem);

                if (dtablem.Rows.Count > 0)
                {
                    MessageBox.Show("Login successful!");
                }
                else
               {
                 MessageBox.Show("Invalid email or password.");
                   }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        static void main(string[] args)
        {
           Application.Run(new Form1());
       

        }

    }
}

