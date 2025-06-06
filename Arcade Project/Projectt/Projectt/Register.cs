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
        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=SignInArcade;Integrated Security=True;");
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SignInArcade.mdf;Integrated Security=True;");

        //static string connStr = @"Data Source=.\SQLEXPRESS;
        //           AttachDbFilename=|DataDirectory|\Database\SignInArcade.mdf;
        //           Integrated Security=True;"; // Optional
        //SqlConnection conn = new SqlConnection(connStr);
        
        public Register()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#6c329d");


            Pswrd_text.PasswordChar = '*';
            Pswrd_text.Font = new Font("ArcadeClassic", 14, FontStyle.Bold);
        }

        #region Register Button

        private void buttonRegister_Click(object sender, EventArgs e)
        {
                string email = txt_Email.Text;
                string password = Pswrd_text.Text;
                
                if(validEmail(email) && validPassword(password))
                {
                    try
                    {
                        Player player = new Player(email, password);        // create new player object
                        string query = "INSERT INTO dbo.Arcade (Email, Password) VALUES (@Email, @Password)";
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // for the sound effect
                            buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
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
            else
            {
                MessageBox.Show("Enter a valid Email Or Password");
                MessageBox.Show("Password must be of length 8\n1 Special character\n1 Number at least");
                MessageBox.Show("Email must end with @gmail.com or @yahoo.com or @outlook.com");
            }
        }
               
        #endregion

        #region Email And Password Restrictions Functions
        private bool validEmail(string email)
        {
            String temp = "";
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    for (int j = (i + 1); j < email.Length; j++)
                    {
                        temp += email[j];   // saved whatever is after the @
                    }
                    break;
                }
            }
            // valids: outlook.com, yahoo.com, gmail.com (Outlook.com)
            if (temp.ToLower() == "yahoo.com" ||
                temp.ToLower() == "gmail.com" ||
                temp.ToLower() == "outlook.com")
            {
                return true;
            }

            return false;
        }

        private bool validPassword(string password)
        {
            bool valid1 = false;
            bool valid2 = false;
            // first check that length >=8
            int size = password.Length;
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] specialChars = { '!', '#', '$', '&', '_', '?' };
            if (size >= 8)
            {
                for (int i = 0; i < size; i++)
                {
                    foreach (char number in numbers)
                    {
                        if (password[i] == number)
                        {
                            valid1 = true;
                            break;
                        }
                    }
                    foreach (char special in specialChars)
                    {
                        if (password[i] == special)
                        {
                            valid2 = true;
                            break;
                        }
                    }
                }
            }

            if (valid1 && valid2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        static void main(string[] args)
        {
            Application.Run(new Login());
        }

    }
}