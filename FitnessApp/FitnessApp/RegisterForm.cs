using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FitnessApp
{
    public partial class RegisterForm : Form
    {
        private string connectionString =globals.connectionString;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            int age;
            float height, weight, waistCircumference;
            string gender = cmbGender.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                MessageBox.Show("Please enter a valid name (at least 3 characters).");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out age) || age < 18 || age > 100)
            {
                MessageBox.Show("Please enter a valid age (between 18 and 100).");
                return;
            }

            if (!float.TryParse(txtHeight.Text, out height) || height <= 0 || height > 250)
            {
                MessageBox.Show("Please enter a valid height (0–250 cm).");
                return;
            }

            if (!float.TryParse(txtWeight.Text, out weight) || weight <= 0 || weight > 300)
            {
                MessageBox.Show("Please enter a valid weight (0–300 kg).");
                return;
            }

            if (!float.TryParse(txtWaistCircumference.Text, out waistCircumference) || waistCircumference <= 0 || waistCircumference > 200)
            {
                MessageBox.Show("Please enter a valid waist circumference (0–200 cm).");
                return;
            }

            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please select a gender.");
                return;
            }


            float bmi = CalculateBMI(weight, height);
            float muscleRatio = CalculateMuscleRatio(weight, height, waistCircumference);
            float fatRatio = CalculateFatRatio(weight, height, waistCircumference);

            if (RegisterUser(name, email, password, age, height, weight, waistCircumference, bmi, muscleRatio, fatRatio, gender))
            {
                MessageBox.Show("Kayıt başarılı!");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kayıt başarısız. E-posta zaten alınmış olabilir.");
            }
        }

        private bool RegisterUser(string name, string email, string password, int age, float height, float weight, float waistCircumference, float bmi, float muscleRatio, float fatRatio, string gender)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = @"
            SELECT COUNT(1)
            FROM [dbo].[Users]
            WHERE [email] = @Email
        ";
                using (var checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                        return false;
                }

                string insertUserQuery = @"
            INSERT INTO [dbo].[Users] ([name], [email], [password])
            VALUES (@Name, @Email, @Password);
            SELECT CAST(SCOPE_IDENTITY() AS INT);
        ";
                int userId;
                using (var insertCmd = new SqlCommand(insertUserQuery, connection))
                {
                    insertCmd.Parameters.Add("@Name", SqlDbType.NVarChar, 255).Value = name;
                    insertCmd.Parameters.Add("@Email", SqlDbType.NVarChar, 255).Value = email;
                    insertCmd.Parameters.Add("@Password", SqlDbType.NVarChar, 128).Value = password;

                    userId = Convert.ToInt32(insertCmd.ExecuteScalar());
                }


                string insertInfoQuery = @"
            INSERT INTO [dbo].[UserInfos]
            (
                [userId],
                [updated_at],
                [age],
                [height],
                [weight],
                [waistCircumference],
                [body_mass_index],
                [muscle_ratio],
                [fat_ratio],
                [gender]
            )
            VALUES
            (
                @UserId,
                GETDATE(),
                @Age,
                @Height,
                @Weight,
                @WaistCircumference,
                @BMI,
                @MuscleRatio,
                @FatRatio,
                @Gender
            );
        ";

                using (var infoCmd = new SqlCommand(insertInfoQuery, connection))
                {
                    infoCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    infoCmd.Parameters.Add("@Age", SqlDbType.Int).Value = age;
                    infoCmd.Parameters.Add("@Height", SqlDbType.Float).Value = height;
                    infoCmd.Parameters.Add("@Weight", SqlDbType.Float).Value = weight;
                    infoCmd.Parameters.Add("@WaistCircumference", SqlDbType.Float).Value = waistCircumference;
                    infoCmd.Parameters.Add("@BMI", SqlDbType.Float).Value = bmi;
                    infoCmd.Parameters.Add("@MuscleRatio", SqlDbType.Float).Value = muscleRatio;
                    infoCmd.Parameters.Add("@FatRatio", SqlDbType.Float).Value = fatRatio;
                    infoCmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 20).Value = gender;

                    infoCmd.ExecuteNonQuery();
                }

                return true;
            }
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(email);
        }

        private float CalculateBMI(float weight, float height)
        {
            return weight / (height / 100) / (height / 100);
        }

        private float CalculateMuscleRatio(float weight, float height, float waistCircumference)
        {
            return (weight / height) * 0.15f;
        }

        private float CalculateFatRatio(float weight, float height, float waistCircumference)
        {
            return (waistCircumference / weight) * 0.05f;
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
