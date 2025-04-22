using System;
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
                MessageBox.Show("Lütfen geçerli bir isim girin (en az 3 karakter).");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Geçerli bir e-posta adresi girin.");
                return;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter uzunluğunda olmalıdır.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out age) || age < 18 || age > 100)
            {
                MessageBox.Show("Lütfen geçerli bir yaş girin (18-100 arası).");
                return;
            }

            if (!float.TryParse(txtHeight.Text, out height) || height <= 0 || height > 250)
            {
                MessageBox.Show("Lütfen geçerli bir boy girin (0-250 cm).");
                return;
            }

            if (!float.TryParse(txtWeight.Text, out weight) || weight <= 0 || weight > 300)
            {
                MessageBox.Show("Lütfen geçerli bir kilo girin (0-300 kg).");
                return;
            }

            if (!float.TryParse(txtWaistCircumference.Text, out waistCircumference) || waistCircumference <= 0 || waistCircumference > 200)
            {
                MessageBox.Show("Lütfen geçerli bir bel çevresi girin (0-200 cm).");
                return;
            }

            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Lütfen bir cinsiyet seçin.");
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
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM user WHERE email = @Email";
                using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);
                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0)
                        return false;
                }

                string query = "INSERT INTO user (name, email, password) VALUES (@Name, @Email, @Password)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                }

                long userId = connection.LastInsertRowId;

                string infoQuery = @"INSERT INTO userInfos 
                    (userId, updated_at, age, height, weight, waistCircumference, body_mass_index, muscle_ratio, fat_ratio, gender) 
                    VALUES 
                    (@UserId, datetime('now'), @Age, @Height, @Weight, @WaistCircumference, @BMI, @MuscleRatio, @FatRatio, @Gender)";

                using (var infoCmd = new SQLiteCommand(infoQuery, connection))
                {
                    infoCmd.Parameters.AddWithValue("@UserId", userId);
                    infoCmd.Parameters.AddWithValue("@Age", age);
                    infoCmd.Parameters.AddWithValue("@Height", height);
                    infoCmd.Parameters.AddWithValue("@Weight", weight);
                    infoCmd.Parameters.AddWithValue("@WaistCircumference", waistCircumference);
                    infoCmd.Parameters.AddWithValue("@BMI", bmi);
                    infoCmd.Parameters.AddWithValue("@MuscleRatio", muscleRatio);
                    infoCmd.Parameters.AddWithValue("@FatRatio", fatRatio);
                    infoCmd.Parameters.AddWithValue("@Gender", gender);
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
