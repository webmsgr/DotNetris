namespace DotNetris
{
    partial class MultiplayerForm
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
            DotNetrisLbl = new Label();
            SuspendLayout();
            // 
            // DotNetrisLbl
            // 
            DotNetrisLbl.BackColor = System.Drawing.Color.Transparent;
            DotNetrisLbl.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DotNetrisLbl.ForeColor = System.Drawing.Color.Red;
            DotNetrisLbl.Location = new Point(144, 47);
            DotNetrisLbl.Name = "DotNetrisLbl";
            DotNetrisLbl.Size = new Size(453, 65);
            DotNetrisLbl.TabIndex = 4;
            DotNetrisLbl.Text = "DOTNETRIS";
            DotNetrisLbl.TextAlign = ContentAlignment.MiddleCenter;
            DotNetrisLbl.UseMnemonic = false;
            DotNetrisLbl.Click += DotNetrisLbl_Click;
            // 
            // MultiplayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DotNetrisLbl);
            Name = "MultiplayerForm";
            Text = "Multiplayer";
            ResumeLayout(false);
        }

        #endregion

        private Label DotNetrisLbl;
    }
}