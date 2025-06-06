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
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SignInArcade.mdf;Integrated Security=True;");
        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=SignInArcade;Integrated Security=True;");
        
        //static string connStr = @"Data Source=.\SQLEXPRESS;
        //           AttachDbFilename=|DataDirectory|\Database\SignInArcade.mdf;
        //           Integrated Security=True;"; // Optional
        //SqlConnection conn = new SqlConnection(connStr);


        Player player;
        public Login()  // default constructor
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#6c329d");
            Pswrd_text.PasswordChar = '*';
            Pswrd_text.Font = new Font("ArcadeClassic", 14, FontStyle.Bold);
            songPlayer = new SoundPlayer(@"Music\ArcadeLoginSong.wav");
            songPlayer.Play();
        }

        #region Login Button
        private void buttonLogin_Click(object sender, EventArgs e) 
        {   
            try
            {
                string email = txt_Email.Text;
                string password = Pswrd_text.Text;

                // create new player object
                player = new Player(email, password);

                // Correct SQL query with parameterized values
                string query = "SELECT * FROM dbo.Arcade WHERE Email = @Email AND Password = @Password";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtablem = new DataTable();
                sda.Fill(dtablem);

                if (dtablem.Rows.Count > 0)
                {
                    // for the sound effect
                    buttonEffect = new SoundPlayer(@"Music\ButtonClick.wav");
                    buttonEffect.Play();

                    // messagebox for login
                    MessageBox.Show("Login successful!");

                    // next page    (DEFAULT CONSTRUCTOR)
                    Ticket ticket1 = new Ticket(player);
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

        #endregion

        #region Register Button
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerPage = new Register();
            registerPage.Show();
            registerPage.FormClosed += (s, args) => this.Show();
        }
        #endregion

        #region alreadyAndAdmin behaviour
        private void label2_Click(object sender, EventArgs e)
        {
            LoginAdmin login = new LoginAdmin();
            login.Show();
            this.Hide();
            login.FormClosed += (s, args) => this.Show();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.DarkTurquoise;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }
        #endregion


        static void main(string[] args)
        {
            Application.Run(new Login());
        }

    }
}

