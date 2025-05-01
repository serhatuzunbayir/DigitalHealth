using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FitnessApp
{
    public partial class WorkoutProgressForm : Form
    {
        public WorkoutProgressForm()
        {
            InitializeComponent();
            this.Load += WorkoutProgressForm_Load;
        }

        private void WorkoutProgressForm_Load(object sender, EventArgs e)
        {
            listWorkouts.View = View.Details;
            listWorkouts.FullRowSelect = true;
            listWorkouts.GridLines = true;

            listWorkouts.Columns.Clear();
            listWorkouts.Columns.Add("Description", 200);
            listWorkouts.Columns.Add("Coverage", 100);

            comboClients.Items.Clear();

            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT u.id, u.name 
                    FROM [Users] u
                    INNER JOIN CustomerTrainerMatches m ON u.id = m.customer_id
                    WHERE m.trainer_id = 1";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string display = $"{reader["id"]} - {reader["name"]}";
                        comboClients.Items.Add(display);
                    }
                }
            }

            comboClients.SelectedIndexChanged += comboClients_SelectedIndexChanged;
        }

        private void comboClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            listWorkouts.Items.Clear();

            if (comboClients.SelectedItem == null) return;

            string selected = comboClients.SelectedItem.ToString();
            int userId = Convert.ToInt32(selected.Split('-')[0].Trim());

            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT description, coverage
                    FROM WorkoutPlan
                    WHERE userId = @userId
                    ORDER BY planId ASC";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        int total = 0;
                        int completed = 0;

                        while (reader.Read())
                        {
                            total++;
                            string desc = reader["description"].ToString();
                            string covStr = reader["coverage"].ToString();

                            var item = new ListViewItem(desc);
                            item.SubItems.Add($"{covStr}%");
                            listWorkouts.Items.Add(item);

                            if (int.TryParse(covStr, out int cov) && cov >= 100)
                                completed++;
                        }

                        if (total > 0)
                        {
                            int percentage = (int)((completed * 100.0) / total);
                            progressBar.Value = percentage;
                            lblProgress.Text = $"Progress: {percentage}% ({completed}/{total})";
                        }
                        else
                        {
                            progressBar.Value = 0;
                            lblProgress.Text = "No workout plans found.";
                        }
                    }
                }
            }
        }

        // 🔧 Bu method sadece hatayı ortadan kaldırmak için var
        private void listWorkouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Şu an kullanılmıyor, ama Designer çağırıyor
        }
    }
}
