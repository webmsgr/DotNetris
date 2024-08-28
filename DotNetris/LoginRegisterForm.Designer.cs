namespace DotNetris
{
    partial class LoginRegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginRegisterForm));
            RegisterButton = new Button();
            LoginUsername = new TextBox();
            UsernameLbl = new Label();
            PasswordLbl = new Label();
            LoginBtn1 = new Button();
            OrLbl = new Label();
            LoginLbl = new Label();
            StayLoggedIn = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            RegisterUsername = new TextBox();
            label5 = new Label();
            label6 = new Label();
            ExitBtn4 = new Button();
            LoginPassword = new MaskedTextBox();
            RegisterPassword = new MaskedTextBox();
            RegisterPasswordConfirm = new MaskedTextBox();
            SuspendLayout();
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = System.Drawing.Color.Black;
            RegisterButton.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RegisterButton.ForeColor = System.Drawing.Color.MediumPurple;
            RegisterButton.Location = new Point(788, 302);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(145, 71);
            RegisterButton.TabIndex = 2;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // LoginUsername
            // 
            LoginUsername.BackColor = System.Drawing.Color.Black;
            LoginUsername.ForeColor = System.Drawing.Color.White;
            LoginUsername.Location = new Point(195, 149);
            LoginUsername.Name = "LoginUsername";
            LoginUsername.Size = new Size(184, 23);
            LoginUsername.TabIndex = 3;
            // 
            // UsernameLbl
            // 
            UsernameLbl.AutoSize = true;
            UsernameLbl.BackColor = System.Drawing.Color.Transparent;
            UsernameLbl.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameLbl.ForeColor = System.Drawing.Color.Yellow;
            UsernameLbl.Location = new Point(51, 141);
            UsernameLbl.Name = "UsernameLbl";
            UsernameLbl.Size = new Size(129, 30);
            UsernameLbl.TabIndex = 5;
            UsernameLbl.Text = "Username: ";
            UsernameLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // PasswordLbl
            // 
            PasswordLbl.BackColor = System.Drawing.Color.Transparent;
            PasswordLbl.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordLbl.ForeColor = System.Drawing.Color.Lime;
            PasswordLbl.Location = new Point(51, 201);
            PasswordLbl.Name = "PasswordLbl";
            PasswordLbl.Size = new Size(129, 44);
            PasswordLbl.TabIndex = 6;
            PasswordLbl.Text = "Password: ";
            PasswordLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // LoginBtn1
            // 
            LoginBtn1.BackColor = System.Drawing.Color.Black;
            LoginBtn1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginBtn1.ForeColor = System.Drawing.Color.BlueViolet;
            LoginBtn1.Location = new Point(234, 302);
            LoginBtn1.Name = "LoginBtn1";
            LoginBtn1.Size = new Size(145, 71);
            LoginBtn1.TabIndex = 7;
            LoginBtn1.Text = "Log In";
            LoginBtn1.UseVisualStyleBackColor = false;
            LoginBtn1.Click += LoginBtn1_Click;
            // 
            // OrLbl
            // 
            OrLbl.BackColor = System.Drawing.Color.Transparent;
            OrLbl.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OrLbl.ForeColor = System.Drawing.Color.Red;
            OrLbl.Location = new Point(447, 181);
            OrLbl.Name = "OrLbl";
            OrLbl.Size = new Size(81, 42);
            OrLbl.TabIndex = 8;
            OrLbl.Text = "OR";
            OrLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // LoginLbl
            // 
            LoginLbl.AutoSize = true;
            LoginLbl.BackColor = System.Drawing.Color.Transparent;
            LoginLbl.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginLbl.ForeColor = System.Drawing.Color.Red;
            LoginLbl.Location = new Point(81, 53);
            LoginLbl.Name = "LoginLbl";
            LoginLbl.Size = new Size(277, 30);
            LoginLbl.TabIndex = 9;
            LoginLbl.Text = "Already have an account?";
            LoginLbl.Click += LoginLbl_Click;
            // 
            // StayLoggedIn
            // 
            StayLoggedIn.AutoSize = true;
            StayLoggedIn.BackColor = System.Drawing.Color.Transparent;
            StayLoggedIn.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StayLoggedIn.ForeColor = System.Drawing.Color.Cyan;
            StayLoggedIn.Location = new Point(81, 326);
            StayLoggedIn.Name = "StayLoggedIn";
            StayLoggedIn.Size = new Size(143, 27);
            StayLoggedIn.TabIndex = 10;
            StayLoggedIn.Text = "Save Password";
            StayLoggedIn.UseVisualStyleBackColor = false;
            StayLoggedIn.CheckedChanged += StayLoggedIn_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label1.Location = new Point(123, 92);
            label1.Name = "label1";
            label1.Size = new Size(176, 35);
            label1.TabIndex = 11;
            label1.Text = "Log In Here: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label2.Location = new Point(612, 53);
            label2.Name = "label2";
            label2.Size = new Size(254, 30);
            label2.TabIndex = 12;
            label2.Text = "Don't have an account?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.Yellow;
            label3.Location = new Point(641, 92);
            label3.Name = "label3";
            label3.Size = new Size(180, 35);
            label3.TabIndex = 13;
            label3.Text = "Register Now:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.Color.Lime;
            label4.Location = new Point(528, 143);
            label4.Name = "label4";
            label4.Size = new Size(215, 30);
            label4.TabIndex = 14;
            label4.Text = "Desired Username: ";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // RegisterUsername
            // 
            RegisterUsername.BackColor = System.Drawing.Color.Black;
            RegisterUsername.ForeColor = System.Drawing.Color.White;
            RegisterUsername.Location = new Point(749, 151);
            RegisterUsername.Name = "RegisterUsername";
            RegisterUsername.Size = new Size(184, 23);
            RegisterUsername.TabIndex = 15;
            // 
            // label5
            // 
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = System.Drawing.Color.Cyan;
            label5.Location = new Point(569, 188);
            label5.Name = "label5";
            label5.Size = new Size(129, 44);
            label5.TabIndex = 16;
            label5.Text = "Password: ";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = System.Drawing.Color.FromArgb(192, 192, 255);
            label6.Location = new Point(528, 246);
            label6.Name = "label6";
            label6.Size = new Size(194, 29);
            label6.TabIndex = 19;
            label6.Text = "Confirm Password: ";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // ExitBtn4
            // 
            ExitBtn4.BackColor = System.Drawing.Color.Black;
            ExitBtn4.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitBtn4.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
            ExitBtn4.Location = new Point(490, 356);
            ExitBtn4.Name = "ExitBtn4";
            ExitBtn4.Size = new Size(142, 61);
            ExitBtn4.TabIndex = 20;
            ExitBtn4.Text = "Exit to Main Menu";
            ExitBtn4.UseVisualStyleBackColor = false;
            // 
            // LoginPassword
            // 
            LoginPassword.BackColor = System.Drawing.Color.Black;
            LoginPassword.ForeColor = System.Drawing.Color.White;
            LoginPassword.Location = new Point(195, 209);
            LoginPassword.Name = "LoginPassword";
            LoginPassword.Size = new Size(184, 23);
            LoginPassword.TabIndex = 21;
            LoginPassword.UseSystemPasswordChar = true;
            // 
            // RegisterPassword
            // 
            RegisterPassword.BackColor = System.Drawing.Color.Black;
            RegisterPassword.ForeColor = System.Drawing.Color.White;
            RegisterPassword.Location = new Point(749, 201);
            RegisterPassword.Name = "RegisterPassword";
            RegisterPassword.Size = new Size(184, 23);
            RegisterPassword.TabIndex = 22;
            RegisterPassword.UseSystemPasswordChar = true;
            // 
            // RegisterPasswordConfirm
            // 
            RegisterPasswordConfirm.BackColor = System.Drawing.Color.Black;
            RegisterPasswordConfirm.ForeColor = System.Drawing.Color.White;
            RegisterPasswordConfirm.Location = new Point(749, 252);
            RegisterPasswordConfirm.Name = "RegisterPasswordConfirm";
            RegisterPasswordConfirm.Size = new Size(184, 23);
            RegisterPasswordConfirm.TabIndex = 23;
            RegisterPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // LoginRegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1038, 450);
            Controls.Add(RegisterPasswordConfirm);
            Controls.Add(RegisterPassword);
            Controls.Add(LoginPassword);
            Controls.Add(ExitBtn4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(RegisterUsername);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(StayLoggedIn);
            Controls.Add(LoginLbl);
            Controls.Add(OrLbl);
            Controls.Add(LoginBtn1);
            Controls.Add(PasswordLbl);
            Controls.Add(UsernameLbl);
            Controls.Add(LoginUsername);
            Controls.Add(RegisterButton);
            Name = "LoginRegisterForm";
            Text = "Login/Register";
            FormClosing += LoginRegisterForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RegisterButton;
        private TextBox LoginUsername;
        private Label UsernameLbl;
        private Label PasswordLbl;
        private Button LoginBtn1;
        private Label OrLbl;
        private Label LoginLbl;
        private CheckBox StayLoggedIn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox RegisterUsername;
        private Label label5;
        private Label label6;
        private Button ExitBtn4;
        private MaskedTextBox LoginPassword;
        private MaskedTextBox RegisterPassword;
        private MaskedTextBox RegisterPasswordConfirm;
    }
}