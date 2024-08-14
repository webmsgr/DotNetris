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
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ExitBtn6);
            Name = "SettingForm";
            Text = "Setting ";
            ResumeLayout(false);
        }

        #endregion

        private Button ExitBtn6;
    }
}