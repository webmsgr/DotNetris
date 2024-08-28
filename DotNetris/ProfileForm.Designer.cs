namespace DotNetris
{
    partial class ProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            ExitBtn5 = new Button();
            groupBox1 = new GroupBox();
            button1 = new Button();
            label1 = new Label();
            DeletePasswordBox = new MaskedTextBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            ChangePasswordBtn = new Button();
            ChangePasswordNew = new MaskedTextBox();
            ChangePasswordOld = new MaskedTextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // ExitBtn5
            // 
            ExitBtn5.BackColor = System.Drawing.Color.Black;
            ExitBtn5.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitBtn5.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
            ExitBtn5.Location = new Point(620, 345);
            ExitBtn5.Name = "ExitBtn5";
            ExitBtn5.Size = new Size(142, 61);
            ExitBtn5.TabIndex = 21;
            ExitBtn5.Text = "Exit to Main Menu";
            ExitBtn5.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(DeletePasswordBox);
            groupBox1.Location = new Point(523, 144);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Delete account";
            // 
            // button1
            // 
            button1.Location = new Point(6, 69);
            button1.Name = "button1";
            button1.Size = new Size(188, 23);
            button1.TabIndex = 2;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 22);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 1;
            label1.Text = "Password";
            // 
            // DeletePasswordBox
            // 
            DeletePasswordBox.Location = new Point(6, 40);
            DeletePasswordBox.Name = "DeletePasswordBox";
            DeletePasswordBox.Size = new Size(188, 23);
            DeletePasswordBox.TabIndex = 0;
            DeletePasswordBox.UseSystemPasswordChar = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(ChangePasswordBtn);
            groupBox2.Controls.Add(ChangePasswordNew);
            groupBox2.Controls.Add(ChangePasswordOld);
            groupBox2.Location = new Point(43, 144);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 160);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Change Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 85);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 4;
            label3.Text = "New Password";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 22);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 3;
            label2.Text = "Old Password";
            // 
            // ChangePasswordBtn
            // 
            ChangePasswordBtn.Location = new Point(6, 131);
            ChangePasswordBtn.Name = "ChangePasswordBtn";
            ChangePasswordBtn.Size = new Size(188, 23);
            ChangePasswordBtn.TabIndex = 2;
            ChangePasswordBtn.Text = "Change Password";
            ChangePasswordBtn.UseVisualStyleBackColor = true;
            ChangePasswordBtn.Click += ChangePasswordBtn_Click;
            // 
            // ChangePasswordNew
            // 
            ChangePasswordNew.ImeMode = ImeMode.NoControl;
            ChangePasswordNew.Location = new Point(6, 102);
            ChangePasswordNew.Name = "ChangePasswordNew";
            ChangePasswordNew.Size = new Size(188, 23);
            ChangePasswordNew.TabIndex = 1;
            ChangePasswordNew.UseSystemPasswordChar = true;
            // 
            // ChangePasswordOld
            // 
            ChangePasswordOld.Location = new Point(6, 40);
            ChangePasswordOld.Name = "ChangePasswordOld";
            ChangePasswordOld.Size = new Size(188, 23);
            ChangePasswordOld.TabIndex = 0;
            ChangePasswordOld.UseSystemPasswordChar = true;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(ExitBtn5);
            Name = "ProfileForm";
            Text = "Profile";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button ExitBtn5;
        private GroupBox groupBox1;
        private Button button1;
        private Label label1;
        private MaskedTextBox DeletePasswordBox;
        private GroupBox groupBox2;
        private Label label3;
        private Label label2;
        private Button ChangePasswordBtn;
        private MaskedTextBox ChangePasswordNew;
        private MaskedTextBox ChangePasswordOld;
    }
}