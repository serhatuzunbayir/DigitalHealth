namespace FitnessApp
{
    partial class WorkoutProgressForm
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
            this.comboClients = new System.Windows.Forms.ComboBox();
            this.listWorkouts = new System.Windows.Forms.ListView();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // comboClients
            // 
            this.comboClients.FormattingEnabled = true;
            this.comboClients.Location = new System.Drawing.Point(55, 61);
            this.comboClients.Name = "comboClients";
            this.comboClients.Size = new System.Drawing.Size(188, 24);
            this.comboClients.TabIndex = 0;
            this.comboClients.SelectedIndexChanged += new System.EventHandler(this.comboClients_SelectedIndexChanged);
            // 
            // listWorkouts
            // 
            this.listWorkouts.FullRowSelect = true;
            this.listWorkouts.GridLines = true;
            this.listWorkouts.HideSelection = false;
            this.listWorkouts.Location = new System.Drawing.Point(55, 104);
            this.listWorkouts.Name = "listWorkouts";
            this.listWorkouts.Size = new System.Drawing.Size(316, 152);
            this.listWorkouts.TabIndex = 1;
            this.listWorkouts.UseCompatibleStateImageBehavior = false;
            this.listWorkouts.View = System.Windows.Forms.View.Details;
            this.listWorkouts.SelectedIndexChanged += new System.EventHandler(this.listWorkouts_SelectedIndexChanged);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(52, 344);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(44, 16);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "label1";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(55, 297);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(188, 23);
            this.progressBar.TabIndex = 3;
            // 
            // WorkoutProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.listWorkouts);
            this.Controls.Add(this.comboClients);
            this.Name = "WorkoutProgressForm";
            this.Text = "WorkoutProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboClients;
        private System.Windows.Forms.ListView listWorkouts;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}