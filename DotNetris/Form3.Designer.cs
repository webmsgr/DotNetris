namespace DotNetris
{
    partial class SettingForm
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
            ExitBtn6 = new Button();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SaveAndConnectBtn = new Button();
            SaveBtn = new Button();
            PortBox = new NumericUpDown();
            HostBox = new TextBox();
            groupBox2 = new GroupBox();
            TLSSecurity = new RadioButton();
            PasswordBox = new MaskedTextBox();
            PasswordSecurity = new RadioButton();
            NoneSecurityRadio = new RadioButton();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PortBox).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // ExitBtn6
            // 
            ExitBtn6.BackColor = System.Drawing.Color.Black;
            ExitBtn6.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitBtn6.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
            ExitBtn6.Location = new Point(573, 331);
            ExitBtn6.Name = "ExitBtn6";
            ExitBtn6.Size = new Size(142, 61);
            ExitBtn6.TabIndex = 21;
            ExitBtn6.Text = "Exit to Main Menu";
            ExitBtn6.UseVisualStyleBackColor = false;
            ExitBtn6.Click += ExitBtn6_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(SaveAndConnectBtn);
            groupBox1.Controls.Add(SaveBtn);
            groupBox1.Controls.Add(PortBox);
            groupBox1.Controls.Add(HostBox);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(28, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(373, 380);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Server";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 309);
            label3.Name = "label3";
            label3.Size = new Size(284, 45);
            label3.TabIndex = 7;
            label3.Text = "Configure the connection to the server here\r\n\r\nThese values should be provided by your server host.\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 66);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 6;
            label2.Text = "Port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 38);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 5;
            label1.Text = "Host";
            // 
            // SaveAndConnectBtn
            // 
            SaveAndConnectBtn.Location = new Point(240, 264);
            SaveAndConnectBtn.Name = "SaveAndConnectBtn";
            SaveAndConnectBtn.Size = new Size(127, 23);
            SaveAndConnectBtn.TabIndex = 4;
            SaveAndConnectBtn.Text = "Save And Connect";
            SaveAndConnectBtn.UseVisualStyleBackColor = true;
            SaveAndConnectBtn.Click += SaveAndConnectBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.ImageAlign = ContentAlignment.MiddleRight;
            SaveBtn.Location = new Point(270, 235);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(75, 23);
            SaveBtn.TabIndex = 3;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += button1_Click;
            // 
            // PortBox
            // 
            PortBox.Location = new Point(34, 64);
            PortBox.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            PortBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PortBox.Name = "PortBox";
            PortBox.Size = new Size(101, 23);
            PortBox.TabIndex = 2;
            PortBox.Value = new decimal(new int[] { 8080, 0, 0, 0 });
            // 
            // HostBox
            // 
            HostBox.Location = new Point(34, 35);
            HostBox.Name = "HostBox";
            HostBox.Size = new Size(100, 23);
            HostBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TLSSecurity);
            groupBox2.Controls.Add(PasswordBox);
            groupBox2.Controls.Add(PasswordSecurity);
            groupBox2.Controls.Add(NoneSecurityRadio);
            groupBox2.Location = new Point(34, 129);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 153);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Security";
            // 
            // TLSSecurity
            // 
            TLSSecurity.AutoSize = true;
            TLSSecurity.Location = new Point(26, 110);
            TLSSecurity.Name = "TLSSecurity";
            TLSSecurity.Size = new Size(43, 19);
            TLSSecurity.TabIndex = 3;
            TLSSecurity.TabStop = true;
            TLSSecurity.Text = "TLS";
            TLSSecurity.UseVisualStyleBackColor = true;
            // 
            // PasswordBox
            // 
            PasswordBox.Enabled = false;
            PasswordBox.Location = new Point(46, 81);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(100, 23);
            PasswordBox.TabIndex = 2;
            PasswordBox.UseSystemPasswordChar = true;
            // 
            // PasswordSecurity
            // 
            PasswordSecurity.AutoSize = true;
            PasswordSecurity.Location = new Point(26, 56);
            PasswordSecurity.Name = "PasswordSecurity";
            PasswordSecurity.Size = new Size(75, 19);
            PasswordSecurity.TabIndex = 1;
            PasswordSecurity.TabStop = true;
            PasswordSecurity.Text = "Password";
            PasswordSecurity.UseVisualStyleBackColor = true;
            PasswordSecurity.CheckedChanged += PasswordSecurity_CheckedChanged;
            // 
            // NoneSecurityRadio
            // 
            NoneSecurityRadio.AutoSize = true;
            NoneSecurityRadio.ImageAlign = ContentAlignment.MiddleRight;
            NoneSecurityRadio.Location = new Point(26, 31);
            NoneSecurityRadio.Name = "NoneSecurityRadio";
            NoneSecurityRadio.Size = new Size(54, 19);
            NoneSecurityRadio.TabIndex = 0;
            NoneSecurityRadio.TabStop = true;
            NoneSecurityRadio.Text = "None";
            NoneSecurityRadio.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(ExitBtn6);
            Name = "SettingForm";
            Text = "Setting ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PortBox).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button ExitBtn6;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton TLSSecurity;
        private MaskedTextBox PasswordBox;
        private RadioButton PasswordSecurity;
        private RadioButton NoneSecurityRadio;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button SaveAndConnectBtn;
        private Button SaveBtn;
        private NumericUpDown PortBox;
        private TextBox HostBox;
    }
}