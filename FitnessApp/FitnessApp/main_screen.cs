using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FitnessApp
{
    public partial class main_screen : Form
    {
        private readonly string connectionString =
            globals.connectionString;

        public main_screen()
        {
            InitializeComponent();
        }

        private void main_screen_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        u.[name], 
                        u.[email], 
                        ui.[age], 
                        ui.[height], 
                        ui.[weight], 
                        ui.[body_mass_index], 
                        ui.[muscle_ratio], 
                        ui.[fat_ratio], 
                        ui.[gender], 
                        ui.[waistCircumference], 
                        wp.[description] AS workout_plan, 
                        fg.[description] AS fitness_goal
                    FROM [dbo].[Users] u
                    LEFT JOIN [dbo].[UserInfos] ui 
                        ON u.[id] = ui.[userId]
                    LEFT JOIN [dbo].[WorkoutPlan] wp 
                        ON u.[id] = wp.[userId]
                    LEFT JOIN [dbo].[FitnessGoals] fg 
                        ON u.[id] = fg.[user_id]
                    WHERE u.[role] = 'customer';
                ";

                using (var cmd = new SqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    var customers = new List<Customer>();
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Name = reader["name"].ToString(),
                            Email = reader["email"].ToString(),
                            Age = reader["age"] as int? ?? 0,
                            Height = reader["height"] as double? ?? 0.0,
                            Weight = reader["weight"] as double? ?? 0.0,
                            BMI = reader["body_mass_index"] as double? ?? 0.0,
                            MuscleRatio = reader["muscle_ratio"] as double? ?? 0.0,
                            FatRatio = reader["fat_ratio"] as double? ?? 0.0,
                            Gender = reader["gender"].ToString(),
                            WaistCircumference = reader["waistCircumference"] as double? ?? 0.0,
                            WorkoutPlan = reader["workout_plan"].ToString(),
                            FitnessGoal = reader["fitness_goal"].ToString()
                        });
                    }

                    var sortedCustomers = customers.OrderBy(c => c.Weight).ToList();

                    listViewCustomers.Items.Clear();
                    foreach (var customer in sortedCustomers)
                    {
                        var row = new string[]
                        {
                            customer.Name,
                            customer.Email,
                            customer.Age.ToString(),
                            customer.Height.ToString("F2"),
                            customer.Weight.ToString("F2"),
                            customer.BMI.ToString("F2"),
                            customer.MuscleRatio.ToString("F2"),
                            customer.FatRatio.ToString("F2"),
                            customer.Gender,
                            customer.WaistCircumference.ToString("F2"),
                            customer.WorkoutPlan,
                            customer.FitnessGoal
                        };

                        var item = new ListViewItem(row);
                        listViewCustomers.Items.Add(item);
                    }

                    Console.WriteLine($"Number of rows: {sortedCustomers.Count}");
                }
            }
        }

        private void listViewCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnManageGoals_Click(object sender, EventArgs e)
        {
            GoalTrackingForm goalForm = new GoalTrackingForm();
            goalForm.Show();
        }

    }

    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }
        public double MuscleRatio { get; set; }
        public double FatRatio { get; set; }
        public string Gender { get; set; }
        public double WaistCircumference { get; set; }
        public string WorkoutPlan { get; set; }
        public string FitnessGoal { get; set; }
    }
}
