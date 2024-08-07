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
            DotNetrisLbl = new Label();
            CreateGameBtn = new Button();
            JoinGameBtn = new Button();
            label1 = new Label();
            label2 = new Label();
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
            // CreateGameBtn
            // 
            CreateGameBtn.AccessibleRole = AccessibleRole.None;
            CreateGameBtn.BackColor = System.Drawing.Color.Black;
            CreateGameBtn.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateGameBtn.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            CreateGameBtn.Location = new Point(156, 161);
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
            JoinGameBtn.Location = new Point(401, 161);
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
            label1.Location = new Point(156, 269);
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
            label2.Location = new Point(401, 269);
            label2.Name = "label2";
            label2.Size = new Size(215, 79);
            label2.TabIndex = 9;
            label2.Text = "Join A Mulitplayer Game";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // MultiplayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(JoinGameBtn);
            Controls.Add(CreateGameBtn);
            Controls.Add(DotNetrisLbl);
            Name = "MultiplayerForm";
            Text = "Multiplayer";
            ResumeLayout(false);
        }

        #endregion

        private Label DotNetrisLbl;
        private Button CreateGameBtn;
        private Button JoinGameBtn;
        private Label label1;
        private Label label2;
    }
}