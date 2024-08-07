namespace DotNetris
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            DotNetrisLbl = new Label();
            MultiPlayerBtn = new Button();
            SinglePlayerBtn = new Button();
            ExitBtn = new Button();
            LogInRegBtn = new Button();
            SettingBtn = new Button();
            ProfileBtn = new Button();
            SuspendLayout();
            // 
            // DotNetrisLbl
            // 
            DotNetrisLbl.BackColor = System.Drawing.Color.Transparent;
            DotNetrisLbl.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DotNetrisLbl.ForeColor = System.Drawing.Color.Red;
            DotNetrisLbl.Location = new Point(149, 53);
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
            MultiPlayerBtn.Location = new Point(266, 135);
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
            SinglePlayerBtn.Location = new Point(266, 198);
            SinglePlayerBtn.Name = "SinglePlayerBtn";
            SinglePlayerBtn.Size = new Size(211, 39);
            SinglePlayerBtn.TabIndex = 2;
            SinglePlayerBtn.Text = "SINGLE PLAYER";
            SinglePlayerBtn.UseVisualStyleBackColor = false;
            // 
            // ExitBtn
            // 
            ExitBtn.BackColor = System.Drawing.Color.Black;
            ExitBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitBtn.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ExitBtn.Location = new Point(266, 350);
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
            LogInRegBtn.Location = new Point(266, 270);
            LogInRegBtn.Name = "LogInRegBtn";
            LogInRegBtn.Size = new Size(211, 46);
            LogInRegBtn.TabIndex = 5;
            LogInRegBtn.Text = "LOG IN/REGESTER";
            LogInRegBtn.UseVisualStyleBackColor = false;
            // 
            // SettingBtn
            // 
            SettingBtn.BackColor = System.Drawing.Color.Black;
            SettingBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SettingBtn.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            SettingBtn.Location = new Point(49, 62);
            SettingBtn.Name = "SettingBtn";
            SettingBtn.Size = new Size(126, 41);
            SettingBtn.TabIndex = 7;
            SettingBtn.Text = "Settings";
            SettingBtn.UseVisualStyleBackColor = false;
            // 
            // ProfileBtn
            // 
            ProfileBtn.BackColor = System.Drawing.Color.Black;
            ProfileBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProfileBtn.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            ProfileBtn.Location = new Point(579, 62);
            ProfileBtn.Name = "ProfileBtn";
            ProfileBtn.Size = new Size(126, 41);
            ProfileBtn.TabIndex = 8;
            ProfileBtn.Text = "Profile";
            ProfileBtn.UseVisualStyleBackColor = false;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(ProfileBtn);
            Controls.Add(SettingBtn);
            Controls.Add(LogInRegBtn);
            Controls.Add(ExitBtn);
            Controls.Add(SinglePlayerBtn);
            Controls.Add(MultiPlayerBtn);
            Controls.Add(DotNetrisLbl);
            Name = "MainMenuForm";
            Text = "Main Menu";
            ResumeLayout(false);
        }

        #endregion

        private Label DotNetrisLbl;
        private Button MultiPlayerBtn;
        private Button SinglePlayerBtn;
        private Button ExitBtn;
        private Button LogInRegBtn;
        private Button SettingBtn;
        private Button ProfileBtn;
    }
}
