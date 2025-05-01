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

namespace FitnessApp
{
    public partial class GoalTrackingForm: Form
    {
        public GoalTrackingForm()
        {
            InitializeComponent();
        }

        private void comboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void GoalTrackingForm_Load(object sender, EventArgs e)
        {
            comboUsers.Items.Clear();
            listGoals.Items.Clear();
            listGoals.Columns.Clear();

            // ListView sütunlarını oluştur
            listGoals.View = View.Details;
            listGoals.FullRowSelect = true;
            listGoals.GridLines = true;

            listGoals.Columns.Add("User ID", 80);
            listGoals.Columns.Add("Description", 250);
            listGoals.Columns.Add("Target Date", 120);
            listGoals.Columns.Add("Coverage (%)", 100);

            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();

                // trainer’a bağlı müşteriler - kullanıcı listesi
                string userQuery = @"
            SELECT u.id, u.name 
            FROM [dbo].[Users] u
            INNER JOIN [dbo].[CustomerTrainerMatches] m ON u.id = m.customer_id
            WHERE m.trainer_id = 1"; // şimdilik trainer_id sabit

                using (var cmd = new SqlCommand(userQuery, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string display = $"{reader["id"]} - {reader["name"]}";
                        comboUsers.Items.Add(display);
                    }
                }

                // hedef listesi
                string goalQuery = @"
            SELECT fg.user_id, fg.description, fg.target_date, fg.coverage
            FROM [dbo].[FitnessGoals] fg
            WHERE fg.trainer_id = 1";

                using (var cmd = new SqlCommand(goalQuery, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["user_id"].ToString());
                        item.SubItems.Add(reader["description"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["target_date"]).ToShortDateString());
                        item.SubItems.Add(reader["coverage"].ToString());

                        listGoals.Items.Add(item);
                    }
                }
            }
        }

        private void btnAddGoal_Click(object sender, EventArgs e)
        {
            if (comboUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            string selected = comboUsers.SelectedItem.ToString();
            int userId = Convert.ToInt32(selected.Split('-')[0].Trim());

            string description = txtDescription.Text.Trim();
            DateTime targetDate = dateTarget.Value;
            int trainerId = 1;
            int coverage = 0;

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please enter a goal description.");
                return;
            }

            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();

                string query = @"
            INSERT INTO FitnessGoals (trainer_id, user_id, description, target_date, created_at, coverage)
            VALUES (@trainer_id, @user_id, @description, @target_date, GETDATE(), @coverage)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@trainer_id", trainerId);
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@target_date", targetDate);
                    command.Parameters.AddWithValue("@coverage", coverage);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Goal added successfully!");
            }

            txtDescription.Clear();
            dateTarget.Value = DateTime.Now;
        }

        private void listGoals_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
