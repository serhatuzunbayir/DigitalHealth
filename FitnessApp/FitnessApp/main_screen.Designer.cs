using System.Windows.Forms;
using System;

namespace FitnessApp
{
    partial class main_screen
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewCustomers;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderEmail;
        private ColumnHeader columnHeaderAge;
        private ColumnHeader columnHeaderHeight;
        private ColumnHeader columnHeaderWeight;
        private ColumnHeader columnHeaderBMI;
        private ColumnHeader columnHeaderMuscleRatio;
        private ColumnHeader columnHeaderFatRatio;
        private ColumnHeader columnHeaderGender;
        private ColumnHeader columnHeaderWaistCircumference;
        private ColumnHeader columnHeaderWorkoutPlan;
        private ColumnHeader columnHeaderFitnessGoal;

        private void InitializeComponent()
        {
            this.listViewCustomers = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBMI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMuscleRatio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFatRatio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWaistCircumference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWorkoutPlan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFitnessGoal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewCustomers
            // 
            this.listViewCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderEmail,
            this.columnHeaderAge,
            this.columnHeaderHeight,
            this.columnHeaderWeight,
            this.columnHeaderBMI,
            this.columnHeaderMuscleRatio,
            this.columnHeaderFatRatio,
            this.columnHeaderGender,
            this.columnHeaderWaistCircumference,
            this.columnHeaderWorkoutPlan,
            this.columnHeaderFitnessGoal});
            this.listViewCustomers.HideSelection = false;
            this.listViewCustomers.Location = new System.Drawing.Point(12, 12);
            this.listViewCustomers.Name = "listViewCustomers";
            this.listViewCustomers.Size = new System.Drawing.Size(1231, 333);
            this.listViewCustomers.TabIndex = 0;
            this.listViewCustomers.UseCompatibleStateImageBehavior = false;
            this.listViewCustomers.View = System.Windows.Forms.View.Details;
            this.listViewCustomers.SelectedIndexChanged += new System.EventHandler(this.listViewCustomers_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 120;
            // 
            // columnHeaderEmail
            // 
            this.columnHeaderEmail.Text = "Email";
            this.columnHeaderEmail.Width = 150;
            // 
            // columnHeaderAge
            // 
            this.columnHeaderAge.Text = "Age";
            this.columnHeaderAge.Width = 50;
            // 
            // columnHeaderHeight
            // 
            this.columnHeaderHeight.Text = "Height (cm)";
            this.columnHeaderHeight.Width = 80;
            // 
            // columnHeaderWeight
            // 
            this.columnHeaderWeight.Text = "Weight (kg)";
            this.columnHeaderWeight.Width = 80;
            // 
            // columnHeaderBMI
            // 
            this.columnHeaderBMI.Text = "BMI";
            this.columnHeaderBMI.Width = 50;
            // 
            // columnHeaderMuscleRatio
            // 
            this.columnHeaderMuscleRatio.Text = "Muscle Ratio";
            this.columnHeaderMuscleRatio.Width = 100;
            // 
            // columnHeaderFatRatio
            // 
            this.columnHeaderFatRatio.Text = "Fat Ratio";
            this.columnHeaderFatRatio.Width = 100;
            // 
            // columnHeaderGender
            // 
            this.columnHeaderGender.Text = "Gender";
            this.columnHeaderGender.Width = 70;
            // 
            // columnHeaderWaistCircumference
            // 
            this.columnHeaderWaistCircumference.Text = "Waist Circumference (cm)";
            this.columnHeaderWaistCircumference.Width = 120;
            // 
            // columnHeaderWorkoutPlan
            // 
            this.columnHeaderWorkoutPlan.Text = "Workout Plan";
            this.columnHeaderWorkoutPlan.Width = 180;
            // 
            // columnHeaderFitnessGoal
            // 
            this.columnHeaderFitnessGoal.Text = "Fitness Goal";
            this.columnHeaderFitnessGoal.Width = 180;
            // 
            // main_screen
            // 
            this.ClientSize = new System.Drawing.Size(1252, 606);
            this.Controls.Add(this.listViewCustomers);
            this.Name = "main_screen";
            this.Text = "Customer Overview";
            this.Load += new System.EventHandler(this.main_screen_Load);
            this.ResumeLayout(false);

        }
    }
}
