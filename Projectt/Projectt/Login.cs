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
using System.Media;

namespace Projectt
{
    public partial class Login: Form
    {
        SoundPlayer songPlayer;
        SoundPlayer buttonEffect;
        public Login()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#6c329d");
            Pswrd_text.PasswordChar = '*';
            Pswrd_text.Font = new Font("ArcadeClassic", 14, FontStyle.Bold);
            songPlayer = new SoundPlayer(@"C:\Users\user\Downloads\ArcadeLoginSong.wav");
            songPlayer.Play();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=SignInArcade;Integrated Security=True;");
        string email;
        int password;
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerPage = new Register();
            registerPage.FormClosed += (s, args) => this.Show();
            registerPage.Show();
        }

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
                    Ticket ticket1 = new Ticket();
                    ticket1.Show();
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
        static void main(string[] args)
        {
           Application.Run(new Login());
       

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginAdmin login = new LoginAdmin();
            login.Show();
            this.Hide();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.DarkTurquoise;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void buttonSignUp_Click_1(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void buttonLogin_MouseHover(object sender, EventArgs e)
        {
            buttonEffect = new SoundPlayer(@"C:\Users\user\Downloads\game-start-6104.wav");
            buttonEffect.Play();
        }
    }
}

