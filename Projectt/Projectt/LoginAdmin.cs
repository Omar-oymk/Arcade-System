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
    public partial class LoginAdmin : Form
    {
        SoundPlayer buttonEffect;
        public LoginAdmin()
        {
            InitializeComponent();


            Pswrd_text.PasswordChar = '*';
            Pswrd_text.Font = new Font("ArcadeClassic", 14, FontStyle.Bold);
        }


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
                    // for the sound effect
                    buttonEffect = new SoundPlayer(@"C:\Users\user\Downloads\game-start-6104.wav");
                    buttonEffect.Play();

                    // messagebox for login
                    MessageBox.Show("Login successful!");

                    // next page
                    MainPage main = new MainPage();
                    main.Show();
                    this.Hide();
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
    }
}
