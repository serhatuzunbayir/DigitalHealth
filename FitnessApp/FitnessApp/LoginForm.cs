using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FitnessApp
{
    public partial class LoginForm : Form
    {
        private string connectionString = globals.connectionString;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (ValidateLogin(email, password))
            {
                MessageBox.Show("Login succesfull!");
                this.Hide(); // Hide the login form
                main_screen mainScreen = new main_screen(); // Create an instance of main_screen
                mainScreen.Show();
            }
            else
            {
                MessageBox.Show("Invalıd e-mail or password.");
            }
        }

        private bool ValidateLogin(string email, string password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM user WHERE email = @Email AND password = @Password AND role='trainer'";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SQLiteDataReader reader = cmd.ExecuteReader(); 
                return reader.HasRows;
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
