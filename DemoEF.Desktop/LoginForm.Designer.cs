namespace Demo.Desktop
{
    partial class LoginForm
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
            lblUserName = new Label();
            txtUserName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            lblUserNameError = new Label();
            lblPasswordError = new Label();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(274, 71);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(65, 15);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "UserName:";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(360, 63);
            txtUserName.Multiline = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(162, 27);
            txtUserName.TabIndex = 1;
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(276, 144);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(63, 15);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Password: ";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(360, 134);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(162, 27);
            txtPassword.TabIndex = 1;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(275, 216);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(114, 39);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(416, 216);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 39);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblUserNameError
            // 
            lblUserNameError.AutoSize = true;
            lblUserNameError.ForeColor = Color.Red;
            lblUserNameError.Location = new Point(363, 99);
            lblUserNameError.Name = "lblUserNameError";
            lblUserNameError.Size = new Size(125, 15);
            lblUserNameError.TabIndex = 3;
            lblUserNameError.Text = "* username is required";
            lblUserNameError.Click += lblUserNameError_Click;
            // 
            // lblPasswordError
            // 
            lblPasswordError.AutoSize = true;
            lblPasswordError.ForeColor = Color.Red;
            lblPasswordError.Location = new Point(364, 172);
            lblPasswordError.Name = "lblPasswordError";
            lblPasswordError.Size = new Size(123, 15);
            lblPasswordError.TabIndex = 3;
            lblPasswordError.Text = "* password is required";
            lblPasswordError.Click += lblPasswordError_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPasswordError);
            Controls.Add(lblUserNameError);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblUserName);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            KeyDown += LoginForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserName;
        private TextBox txtUserName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblUserNameError;
        private Label lblPasswordError;
    }
}