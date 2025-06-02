using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectt
{
    public partial class Register : Form
    {
        SoundPlayer buttonEffect;
        public Register()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#6c329d");


            Pswrd_text.PasswordChar = '*';
            Pswrd_text.Font = new Font("ArcadeClassic", 14, FontStyle.Bold);
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

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txt_Email.Text;
                int password;
                if (!int.TryParse(Pswrd_text.Text, out password))
                {
                    MessageBox.Show("Invalid password format! Please enter a number.");
                    return;
                }
                string query = "INSERT INTO dbo.Arcade (Email, Password) VALUES (@Email, @Password)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // for the sound effect
                    buttonEffect = new SoundPlayer(@"C:\Users\user\Downloads\game-start-6104.wav");
                    buttonEffect.Play();

                    // messagebox for login
                    MessageBox.Show("Registration successful!");

                    // next page
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No record was inserted.");
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


    }
}