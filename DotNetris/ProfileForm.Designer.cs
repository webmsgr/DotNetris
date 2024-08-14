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
            ProfilePictureListBox = new ListBox();
            pictureBox1 = new PictureBox();
            ConfirmBtn = new Button();
            ExitBtn5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ProfilePictureListBox
            // 
            ProfilePictureListBox.FormattingEnabled = true;
            ProfilePictureListBox.ItemHeight = 15;
            ProfilePictureListBox.Location = new Point(142, 33);
            ProfilePictureListBox.Name = "ProfilePictureListBox";
            ProfilePictureListBox.Size = new Size(119, 49);
            ProfilePictureListBox.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // ConfirmBtn
            // 
            ConfirmBtn.Location = new Point(58, 102);
            ConfirmBtn.Name = "ConfirmBtn";
            ConfirmBtn.Size = new Size(136, 53);
            ConfirmBtn.TabIndex = 2;
            ConfirmBtn.Text = "Confirm Changes";
            ConfirmBtn.UseVisualStyleBackColor = true;
            ConfirmBtn.Click += button1_Click;
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
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(ExitBtn5);
            Controls.Add(ConfirmBtn);
            Controls.Add(pictureBox1);
            Controls.Add(ProfilePictureListBox);
            Name = "ProfileForm";
            Text = "Profile";
            
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox ProfilePictureListBox;
        private PictureBox pictureBox1;
        private Button ConfirmBtn;
        private Button ExitBtn5;
    }
}