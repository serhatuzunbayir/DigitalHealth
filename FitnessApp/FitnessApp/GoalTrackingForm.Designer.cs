namespace FitnessApp
{
    partial class GoalTrackingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dateTarget = new System.Windows.Forms.DateTimePicker();
            this.btnAddGoal = new System.Windows.Forms.Button();
            this.listGoals = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // comboUsers
            // 
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(32, 81);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(207, 24);
            this.comboUsers.TabIndex = 0;
            this.comboUsers.SelectedIndexChanged += new System.EventHandler(this.comboUsers_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(32, 145);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(275, 72);
            this.txtDescription.TabIndex = 1;
            // 
            // dateTarget
            // 
            this.dateTarget.Location = new System.Drawing.Point(32, 256);
            this.dateTarget.Name = "dateTarget";
            this.dateTarget.Size = new System.Drawing.Size(200, 22);
            this.dateTarget.TabIndex = 2;
            // 
            // btnAddGoal
            // 
            this.btnAddGoal.Location = new System.Drawing.Point(32, 346);
            this.btnAddGoal.Name = "btnAddGoal";
            this.btnAddGoal.Size = new System.Drawing.Size(84, 37);
            this.btnAddGoal.TabIndex = 3;
            this.btnAddGoal.Text = "Add Goal";
            this.btnAddGoal.UseVisualStyleBackColor = true;
            // 
            // listGoals
            // 
            this.listGoals.FullRowSelect = true;
            this.listGoals.GridLines = true;
            this.listGoals.HideSelection = false;
            this.listGoals.Location = new System.Drawing.Point(432, 68);
            this.listGoals.MultiSelect = false;
            this.listGoals.Name = "listGoals";
            this.listGoals.Size = new System.Drawing.Size(308, 326);
            this.listGoals.TabIndex = 4;
            this.listGoals.UseCompatibleStateImageBehavior = false;
            this.listGoals.View = System.Windows.Forms.View.Details;
            this.listGoals.SelectedIndexChanged += new System.EventHandler(this.listGoals_SelectedIndexChanged);
            // 
            // GoalTrackingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listGoals);
            this.Controls.Add(this.btnAddGoal);
            this.Controls.Add(this.dateTarget);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.comboUsers);
            this.Name = "GoalTrackingForm";
            this.Text = "GoalTrackingForm";
            this.Load += new System.EventHandler(this.GoalTrackingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboUsers;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dateTarget;
        private System.Windows.Forms.Button btnAddGoal;
        private System.Windows.Forms.ListView listGoals;
    }
}