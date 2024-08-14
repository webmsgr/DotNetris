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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiplayerForm));
            DotNetriSMutliLbl = new Label();
            CreateGameBtn = new Button();
            JoinGameBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            ExitBtn2 = new Button();
            SuspendLayout();
            // 
            // DotNetriSMutliLbl
            // 
            DotNetriSMutliLbl.BackColor = System.Drawing.Color.Transparent;
            DotNetriSMutliLbl.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DotNetriSMutliLbl.ForeColor = System.Drawing.Color.Red;
            DotNetriSMutliLbl.Location = new Point(156, 26);
            DotNetriSMutliLbl.Name = "DotNetriSMutliLbl";
            DotNetriSMutliLbl.Size = new Size(460, 133);
            DotNetriSMutliLbl.TabIndex = 4;
            DotNetriSMutliLbl.Text = "DOTNETRIS:  MULTIPLAYER MODE";
            DotNetriSMutliLbl.TextAlign = ContentAlignment.MiddleCenter;
            DotNetriSMutliLbl.UseMnemonic = false;
            DotNetriSMutliLbl.Click += DotNetrisLbl_Click;
            // 
            // CreateGameBtn
            // 
            CreateGameBtn.AccessibleRole = AccessibleRole.None;
            CreateGameBtn.BackColor = System.Drawing.Color.Black;
            CreateGameBtn.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateGameBtn.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            CreateGameBtn.Location = new Point(156, 188);
            CreateGameBtn.Name = "CreateGameBtn";
            CreateGameBtn.Size = new Size(215, 64);
            CreateGameBtn.TabIndex = 6;
            CreateGameBtn.Text = "Create Game";
            CreateGameBtn.UseVisualStyleBackColor = false;
            // 
            // JoinGameBtn
            // 
            JoinGameBtn.BackColor = System.Drawing.Color.Black;
            JoinGameBtn.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JoinGameBtn.ForeColor = System.Drawing.Color.Yellow;
            JoinGameBtn.Location = new Point(401, 188);
            JoinGameBtn.Name = "JoinGameBtn";
            JoinGameBtn.Size = new Size(215, 64);
            JoinGameBtn.TabIndex = 7;
            JoinGameBtn.Text = "Join Game";
            JoinGameBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.Lime;
            label1.Location = new Point(156, 306);
            label1.Name = "label1";
            label1.Size = new Size(215, 79);
            label1.TabIndex = 8;
            label1.Text = "Create A New Multiplayer Game!";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.Cyan;
            label2.Location = new Point(401, 306);
            label2.Name = "label2";
            label2.Size = new Size(215, 79);
            label2.TabIndex = 9;
            label2.Text = "Join A Mulitplayer Game";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // ExitBtn2
            // 
            ExitBtn2.BackColor = System.Drawing.Color.Black;
            ExitBtn2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitBtn2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
            ExitBtn2.Location = new Point(622, 358);
            ExitBtn2.Name = "ExitBtn2";
            ExitBtn2.Size = new Size(142, 61);
            ExitBtn2.TabIndex = 10;
            ExitBtn2.Text = "Exit to Main Menu";
            ExitBtn2.UseVisualStyleBackColor = false;
            // 
            // MultiplayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(ExitBtn2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(JoinGameBtn);
            Controls.Add(CreateGameBtn);
            Controls.Add(DotNetriSMutliLbl);
            Name = "MultiplayerForm";
            Text = "Multiplayer";
            ResumeLayout(false);
        }

        #endregion

        private Label DotNetriSMutliLbl;
        private Button CreateGameBtn;
        private Button JoinGameBtn;
        private Label label1;
        private Label label2;
        private Button ExitBtn2;
    }
}