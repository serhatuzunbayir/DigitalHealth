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
                MessageBox.Show("Giriş başarılı!");
            }
            else
            {
                MessageBox.Show("Geçersiz e-posta veya şifre.");
            }
        }

        private bool ValidateLogin(string email, string password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM user WHERE email = @Email AND password = @Password";
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
    }
}
