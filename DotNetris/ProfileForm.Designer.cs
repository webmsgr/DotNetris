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
            listBox1 = new ListBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            ExitBtn5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(194, 124);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(119, 34);
            listBox1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(81, 139);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(308, 209);
            button1.Name = "button1";
            button1.Size = new Size(95, 53);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
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
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(listBox1);
            Name = "ProfileForm";
            Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private PictureBox pictureBox1;
        private Button button1;
        private Button ExitBtn5;
    }
}