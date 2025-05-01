using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FitnessApp
{
    public partial class main_screen : Form
    {
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
            using (var connection = new SQLiteConnection("Data Source=fitnessApp.db"))
            {
                connection.Open();

                string query = @"
                    SELECT DISTINCT u.name, u.email, ui.age, ui.height, ui.weight, ui.body_mass_index, 
                           ui.muscle_ratio, ui.fat_ratio, ui.gender, ui.waistCircumference, 
                           wp.description AS workout_plan, fg.description AS fitness_goal
                    FROM user u
                    LEFT JOIN userInfos ui ON u.id = ui.userId
                    LEFT JOIN workoutPlan wp ON u.id = wp.userId
                    LEFT JOIN fitnessGoals fg ON u.id = fg.user_id
                    WHERE u.role = 'customer'";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                List<Customer> customers = new List<Customer>();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Age = Convert.ToInt32(reader["age"]),
                        Height = Convert.ToDouble(reader["height"]),
                        Weight = Convert.ToDouble(reader["weight"]),
                        BMI = Convert.ToDouble(reader["body_mass_index"]),
                        MuscleRatio = Convert.ToDouble(reader["muscle_ratio"]),
                        FatRatio = Convert.ToDouble(reader["fat_ratio"]),
                        Gender = reader["gender"].ToString(),
                        WaistCircumference = Convert.ToDouble(reader["waistCircumference"]),
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
                        customer.Height.ToString(),
                        customer.Weight.ToString(),
                        customer.BMI.ToString(),
                        customer.MuscleRatio.ToString(),
                        customer.FatRatio.ToString(),
                        customer.Gender,
                        customer.WaistCircumference.ToString(),
                        customer.WorkoutPlan,
                        customer.FitnessGoal
                    };

                    ListViewItem item = new ListViewItem(row);
                    listViewCustomers.Items.Add(item);
                }

                Console.WriteLine("Number of rows: " + sortedCustomers.Count);
            }
        }

        private void listViewCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
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
