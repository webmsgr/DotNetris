﻿namespace DotNetris
{
    partial class SinglePlayerSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinglePlayerSettingsForm));
            DotNetrisLbl = new Label();
            EasySettingBtn = new Button();
            NormalSettingsBtn = new Button();
            HardSettingsBtn = new Button();
            EasyModeDescriptLbl = new Label();
            NormalModeDescriptLbl = new Label();
            HardModeDescriptLbl = new Label();
            SuspendLayout();
            // 
            // DotNetrisLbl
            // 
            DotNetrisLbl.BackColor = System.Drawing.Color.Transparent;
            DotNetrisLbl.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DotNetrisLbl.ForeColor = System.Drawing.Color.White;
            DotNetrisLbl.Location = new Point(160, 56);
            DotNetrisLbl.Name = "DotNetrisLbl";
            DotNetrisLbl.Size = new Size(453, 65);
            DotNetrisLbl.TabIndex = 5;
            DotNetrisLbl.Text = "DOTNETRIS";
            DotNetrisLbl.TextAlign = ContentAlignment.MiddleCenter;
            DotNetrisLbl.UseMnemonic = false;
            DotNetrisLbl.Click += DotNetrisLbl_Click;
            // 
            // EasySettingBtn
            // 
            EasySettingBtn.BackColor = System.Drawing.Color.Black;
            EasySettingBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EasySettingBtn.ForeColor = System.Drawing.Color.FromArgb(128, 255, 128);
            EasySettingBtn.Location = new Point(149, 196);
            EasySettingBtn.Name = "EasySettingBtn";
            EasySettingBtn.Size = new Size(144, 56);
            EasySettingBtn.TabIndex = 6;
            EasySettingBtn.Text = "Easy Mode";
            EasySettingBtn.UseVisualStyleBackColor = false;
            // 
            // NormalSettingsBtn
            // 
            NormalSettingsBtn.BackColor = System.Drawing.Color.Black;
            NormalSettingsBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NormalSettingsBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 128);
            NormalSettingsBtn.Location = new Point(327, 196);
            NormalSettingsBtn.Name = "NormalSettingsBtn";
            NormalSettingsBtn.Size = new Size(144, 56);
            NormalSettingsBtn.TabIndex = 7;
            NormalSettingsBtn.Text = "Normal Mode";
            NormalSettingsBtn.UseVisualStyleBackColor = false;
            // 
            // HardSettingsBtn
            // 
            HardSettingsBtn.BackColor = System.Drawing.Color.Black;
            HardSettingsBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HardSettingsBtn.ForeColor = System.Drawing.Color.Red;
            HardSettingsBtn.Location = new Point(510, 196);
            HardSettingsBtn.Name = "HardSettingsBtn";
            HardSettingsBtn.Size = new Size(144, 56);
            HardSettingsBtn.TabIndex = 8;
            HardSettingsBtn.Text = "Hard Mode";
            HardSettingsBtn.UseVisualStyleBackColor = false;
            // 
            // EasyModeDescriptLbl
            // 
            EasyModeDescriptLbl.BackColor = System.Drawing.Color.Transparent;
            EasyModeDescriptLbl.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EasyModeDescriptLbl.ForeColor = System.Drawing.Color.Lime;
            EasyModeDescriptLbl.Location = new Point(149, 287);
            EasyModeDescriptLbl.Name = "EasyModeDescriptLbl";
            EasyModeDescriptLbl.Size = new Size(144, 122);
            EasyModeDescriptLbl.TabIndex = 9;
            EasyModeDescriptLbl.Text = "Starts Slower then gets faster, shows the next three pieces. ";
            EasyModeDescriptLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // NormalModeDescriptLbl
            // 
            NormalModeDescriptLbl.BackColor = System.Drawing.Color.Transparent;
            NormalModeDescriptLbl.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NormalModeDescriptLbl.ForeColor = System.Drawing.Color.Yellow;
            NormalModeDescriptLbl.ImageAlign = ContentAlignment.MiddleLeft;
            NormalModeDescriptLbl.Location = new Point(327, 287);
            NormalModeDescriptLbl.Name = "NormalModeDescriptLbl";
            NormalModeDescriptLbl.Size = new Size(144, 122);
            NormalModeDescriptLbl.TabIndex = 10;
            NormalModeDescriptLbl.Text = "Starts at a normal speed and gets fasters, only shows the next piece";
            NormalModeDescriptLbl.TextAlign = ContentAlignment.TopCenter;
            NormalModeDescriptLbl.Click += label2_Click;
            // 
            // HardModeDescriptLbl
            // 
            HardModeDescriptLbl.BackColor = System.Drawing.Color.Transparent;
            HardModeDescriptLbl.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HardModeDescriptLbl.ForeColor = System.Drawing.Color.Red;
            HardModeDescriptLbl.Location = new Point(510, 287);
            HardModeDescriptLbl.Name = "HardModeDescriptLbl";
            HardModeDescriptLbl.Size = new Size(144, 122);
            HardModeDescriptLbl.TabIndex = 11;
            HardModeDescriptLbl.Text = "Starts Fast and gets faster, no previews of the next pieces";
            // 
            // SinglePlayerSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(HardModeDescriptLbl);
            Controls.Add(NormalModeDescriptLbl);
            Controls.Add(EasyModeDescriptLbl);
            Controls.Add(HardSettingsBtn);
            Controls.Add(NormalSettingsBtn);
            Controls.Add(EasySettingBtn);
            Controls.Add(DotNetrisLbl);
            Name = "SinglePlayerSettingsForm";
            Text = "Single Player Settings";
            ResumeLayout(false);
        }

        #endregion

        private Label DotNetrisLbl;
        private Button EasySettingBtn;
        private Button NormalSettingsBtn;
        private Button HardSettingsBtn;
        private Label EasyModeDescriptLbl;
        private Label NormalModeDescriptLbl;
        private Label HardModeDescriptLbl;
    }
}