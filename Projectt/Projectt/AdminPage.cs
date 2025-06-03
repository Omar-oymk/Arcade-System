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
    public partial class AdminPage : Form
    {
        Admin admin;

        public AdminPage(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }
        public AdminPage(Admin admin, Game game) : this(admin)
        {
            GamesStore.games[GamesStore.currentIndex] = game;
        }


        private void AdminPage_Load(object sender, EventArgs e)
        {
            LoadUsers();
            this.FormClosed += (s, args) => Application.Exit();
        }

        #region sidebar
        private void Games_MouseEnter(object sender, EventArgs e)
        {
            Games.ForeColor = Color.White;
        }

        private void Games_MouseLeave(object sender, EventArgs e)
        {
            Games.ForeColor = Color.Black;
        }

        private void Logout_MouseEnter(object sender, EventArgs e)
        {
            Logout.ForeColor = Color.White;
        }

        private void Logout_MouseLeave(object sender, EventArgs e)
        {
            Logout.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        bool panelIsOpen = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int targetWidth = 270;

            if (!panelIsOpen)
            {
                SideBar.Width += 27;

                if (SideBar.Width == targetWidth)
                {
                    panelIsOpen = true;
                    timer1.Stop();
                }
            }

            else
            {
                SideBar.Width -= 30;

                if (SideBar.Width == 0)
                {
                    timer1.Stop();
                    panelIsOpen = false;
                }
            }
        }
        #endregion

        #region clicks
        private void Games_Click(object sender, EventArgs e)
        {
            FlappyDemon game = new FlappyDemon();
            this.Hide();
            game.Show();
            game.FormClosed += (s, args) => this.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
            login.FormClosed += (s, args) => this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddGame addgame = new AddGame(admin);
            addgame.Show();
            this.Hide();
            addgame.FormClosed += (s, args) => this.Show();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)       // REMOVE GAMES
        {
            if (GamesStore.currentIndex > 0 && ImageStore.currentIndex > 0)
            {
                
                ImageStore.images[ImageStore.currentIndex - 1] = null;
                ImageStore.currentIndex--;
                admin.RemoveGame(GamesStore.games[GamesStore.currentIndex - 1]);    // using remove game fn from admin
                GamesStore.currentIndex--;
                MessageBox.Show(Convert.ToString(GamesStore.games[GamesStore.currentIndex].id)); // REMOVE THIS
            }
            else
            {
                MessageBox.Show("CANNOT REMOVE MORE GAMES");
            }

        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ChangePoints changePoints = new ChangePoints(admin);
            changePoints.Show();
            this.Hide();
            changePoints.FormClosed += (s, args) => this.Show();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }
        #endregion

        #region sql reader
        private void LoadUsers()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=SignInArcade;Integrated Security=True;");
            string query = "SELECT ID, Email, Password FROM Arcade";

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Users");
            }
        }

        #endregion
    }
}
