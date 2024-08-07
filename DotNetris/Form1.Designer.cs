namespace DotNetris
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DotNetrisLbl = new Label();
            MultiPlayerBtn = new Button();
            SinglePlayerBtn = new Button();
            SettingsBtn = new Button();
            ExitBtn = new Button();
            LogInRegBtn = new Button();
            ProfileLinkLbl = new LinkLabel();
            SuspendLayout();
            // 
            // DotNetrisLbl
            // 
            DotNetrisLbl.BackColor = System.Drawing.Color.Transparent;
            DotNetrisLbl.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DotNetrisLbl.ForeColor = System.Drawing.Color.Red;
            DotNetrisLbl.Location = new Point(111, 54);
            DotNetrisLbl.Name = "DotNetrisLbl";
            DotNetrisLbl.Size = new Size(453, 65);
            DotNetrisLbl.TabIndex = 0;
            DotNetrisLbl.Text = "DOTNETRIS";
            DotNetrisLbl.TextAlign = ContentAlignment.MiddleCenter;
            DotNetrisLbl.UseMnemonic = false;
            DotNetrisLbl.Click += DotNetrisLbl_Click;
            // 
            // MultiPlayerBtn
            // 
            MultiPlayerBtn.BackColor = System.Drawing.Color.Black;
            MultiPlayerBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MultiPlayerBtn.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            MultiPlayerBtn.Location = new Point(236, 140);
            MultiPlayerBtn.Name = "MultiPlayerBtn";
            MultiPlayerBtn.Size = new Size(211, 33);
            MultiPlayerBtn.TabIndex = 1;
            MultiPlayerBtn.Text = "MULTIPLAYER ";
            MultiPlayerBtn.UseVisualStyleBackColor = false;
            // 
            // SinglePlayerBtn
            // 
            SinglePlayerBtn.BackColor = System.Drawing.Color.Black;
            SinglePlayerBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SinglePlayerBtn.ForeColor = System.Drawing.Color.Yellow;
            SinglePlayerBtn.Location = new Point(236, 188);
            SinglePlayerBtn.Name = "SinglePlayerBtn";
            SinglePlayerBtn.Size = new Size(211, 39);
            SinglePlayerBtn.TabIndex = 2;
            SinglePlayerBtn.Text = "SINGLE PLAYER";
            SinglePlayerBtn.UseVisualStyleBackColor = false;
            // 
            // SettingsBtn
            // 
            SettingsBtn.BackColor = System.Drawing.Color.Black;
            SettingsBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SettingsBtn.ForeColor = System.Drawing.Color.Lime;
            SettingsBtn.Location = new Point(236, 246);
            SettingsBtn.Name = "SettingsBtn";
            SettingsBtn.Size = new Size(211, 43);
            SettingsBtn.TabIndex = 3;
            SettingsBtn.Text = "SETTINGS";
            SettingsBtn.UseVisualStyleBackColor = false;
            // 
            // ExitBtn
            // 
            ExitBtn.BackColor = System.Drawing.Color.Black;
            ExitBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitBtn.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ExitBtn.Location = new Point(236, 375);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(211, 47);
            ExitBtn.TabIndex = 4;
            ExitBtn.Text = "EXIT";
            ExitBtn.UseVisualStyleBackColor = false;
            // 
            // LogInRegBtn
            // 
            LogInRegBtn.BackColor = System.Drawing.Color.Black;
            LogInRegBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogInRegBtn.ForeColor = System.Drawing.Color.Cyan;
            LogInRegBtn.Location = new Point(236, 307);
            LogInRegBtn.Name = "LogInRegBtn";
            LogInRegBtn.Size = new Size(211, 46);
            LogInRegBtn.TabIndex = 5;
            LogInRegBtn.Text = "LOG IN/REGESTER";
            LogInRegBtn.UseVisualStyleBackColor = false;
            // 
            // ProfileLinkLbl
            // 
            ProfileLinkLbl.BackColor = System.Drawing.Color.Transparent;
            ProfileLinkLbl.Cursor = Cursors.Hand;
            ProfileLinkLbl.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProfileLinkLbl.LinkColor = System.Drawing.Color.Fuchsia;
            ProfileLinkLbl.Location = new Point(628, 54);
            ProfileLinkLbl.Name = "ProfileLinkLbl";
            ProfileLinkLbl.Size = new Size(133, 35);
            ProfileLinkLbl.TabIndex = 6;
            ProfileLinkLbl.TabStop = true;
            ProfileLinkLbl.Text = "Profile";
            ProfileLinkLbl.TextAlign = ContentAlignment.TopCenter;
            ProfileLinkLbl.VisitedLinkColor = System.Drawing.Color.FromArgb(255, 128, 255);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(ProfileLinkLbl);
            Controls.Add(LogInRegBtn);
            Controls.Add(ExitBtn);
            Controls.Add(SettingsBtn);
            Controls.Add(SinglePlayerBtn);
            Controls.Add(MultiPlayerBtn);
            Controls.Add(DotNetrisLbl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label DotNetrisLbl;
        private Button MultiPlayerBtn;
        private Button SinglePlayerBtn;
        private Button SettingsBtn;
        private Button ExitBtn;
        private Button LogInRegBtn;
        private LinkLabel ProfileLinkLbl;
    }
}
