using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FitnessApp
{
    public partial class LoginForm : Form
    {
        private string connectionString = globals.connectionString;
        private SqlConnection cn;

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
                this.Hide(); 
                main_screen mainScreen = new main_screen(); 
                mainScreen.Show();
            }
            else
            {
                MessageBox.Show("Invalıd e-mail or password.");
            }
        }



    private bool ValidateLogin(string email, string password)
        {

            string query = @"
                SELECT COUNT(1)
                FROM [dbo].[Users]
                WHERE [email] = @Email
                  AND [password] = @Password
                  AND [role] = 'trainer'
                ";

                using (var cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 255).Value = email;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 128).Value = password;

                int matchCount = (int)cmd.ExecuteScalar();
                cn.Close();

                return matchCount > 0;
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
            string connStr = globals.connectionString;
            cn = new SqlConnection(connStr);


            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }   

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
