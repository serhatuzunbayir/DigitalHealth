namespace FitnessApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkRegister;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;

        private void InitializeComponent()
        {
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkRegister = new System.Windows.Forms.LinkLabel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.lblPassword);
            this.panelMain.Controls.Add(this.txtPassword);
            this.panelMain.Controls.Add(this.btnLogin);
            this.panelMain.Controls.Add(this.linkRegister);
            this.panelMain.Location = new System.Drawing.Point(100, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 700);
            this.panelMain.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Fitness App Giriş";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(70, 10);
            this.lblTitle.Size = new System.Drawing.Size(260, 40);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblEmail
            // 
            this.lblEmail.Text = "E-mail:";
            this.lblEmail.Location = new System.Drawing.Point(30, 70);
            this.lblEmail.Size = new System.Drawing.Size(80, 25);
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 70);
            this.txtEmail.Size = new System.Drawing.Size(240, 25);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // lblPassword
            // 
            this.lblPassword.Text = "Şifre:";
            this.lblPassword.Location = new System.Drawing.Point(30, 110);
            this.lblPassword.Size = new System.Drawing.Size(80, 25);
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 110);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(240, 25);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // btnLogin
            // 
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.Location = new System.Drawing.Point(120, 160);
            this.btnLogin.Size = new System.Drawing.Size(240, 35);
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // 
            // linkRegister
            // 
            this.linkRegister.Text = "Hesabınız yok mu? Kayıt olabilirsiniz.";
            this.linkRegister.Location = new System.Drawing.Point(120, 210);
            this.linkRegister.AutoSize = true;
            this.linkRegister.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister_LinkClicked);

            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "LoginForm";
            this.Text = "Giriş Yap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
