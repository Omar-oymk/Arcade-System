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
        Admin admin;
        public LoginAdmin()
        {
            InitializeComponent();


            Pswrd_text.PasswordChar = '*';
            Pswrd_text.Font = new Font("ArcadeClassic", 14, FontStyle.Bold);
        }


        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=SignInArcade;Integrated Security=True;");
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {

                string email = txt_Email.Text;
                string password = Pswrd_text.Text;

                // create new admin object
                admin = new Admin(email, password);

                // Correct SQL query with parameterized values
                string query = "SELECT * FROM dbo.Arcade WHERE Email = @Email AND Password = @Password AND IsAdmin = 1";
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
                    buttonEffect = new SoundPlayer(@"C:\Users\user\Downloads\game-start-6104.wav");
                    buttonEffect.Play();

                    // messagebox for login
                    MessageBox.Show("Login successful!");

                    // next page
                    AdminPage main = new AdminPage(admin);
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid email or password or Is not an admin");
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
