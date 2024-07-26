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
            DotNetrisLbl = new Label();
            MulitPlayerBtn = new Button();
            SinglePlayerBtn = new Button();
            SettingsBtn = new Button();
            ExitBtn = new Button();
            SuspendLayout();
            // 
            // DotNetrisLbl
            // 
            DotNetrisLbl.Font = new Font("Tahoma", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DotNetrisLbl.Location = new Point(166, 53);
            DotNetrisLbl.Name = "DotNetrisLbl";
            DotNetrisLbl.Size = new Size(453, 65);
            DotNetrisLbl.TabIndex = 0;
            DotNetrisLbl.Text = "DOTNETRIS";
            DotNetrisLbl.TextAlign = ContentAlignment.MiddleCenter;
            DotNetrisLbl.UseMnemonic = false;
            // 
            // MulitPlayerBtn
            // 
            MulitPlayerBtn.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MulitPlayerBtn.Location = new Point(283, 152);
            MulitPlayerBtn.Name = "MulitPlayerBtn";
            MulitPlayerBtn.Size = new Size(211, 33);
            MulitPlayerBtn.TabIndex = 1;
            MulitPlayerBtn.Text = "MULTIPLAYER ";
            MulitPlayerBtn.UseVisualStyleBackColor = true;
            // 
            // SinglePlayerBtn
            // 
            SinglePlayerBtn.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SinglePlayerBtn.Location = new Point(283, 205);
            SinglePlayerBtn.Name = "SinglePlayerBtn";
            SinglePlayerBtn.Size = new Size(211, 39);
            SinglePlayerBtn.TabIndex = 2;
            SinglePlayerBtn.Text = "SINGLE PLAYER";
            SinglePlayerBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsBtn
            // 
            SettingsBtn.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SettingsBtn.Location = new Point(283, 264);
            SettingsBtn.Name = "SettingsBtn";
            SettingsBtn.Size = new Size(211, 43);
            SettingsBtn.TabIndex = 3;
            SettingsBtn.Text = "SETTINGS";
            SettingsBtn.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            ExitBtn.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExitBtn.Location = new Point(283, 331);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(211, 47);
            ExitBtn.TabIndex = 4;
            ExitBtn.Text = "EXIT";
            ExitBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ExitBtn);
            Controls.Add(SettingsBtn);
            Controls.Add(SinglePlayerBtn);
            Controls.Add(MulitPlayerBtn);
            Controls.Add(DotNetrisLbl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label DotNetrisLbl;
        private Button MulitPlayerBtn;
        private Button SinglePlayerBtn;
        private Button SettingsBtn;
        private Button ExitBtn;
    }
}
