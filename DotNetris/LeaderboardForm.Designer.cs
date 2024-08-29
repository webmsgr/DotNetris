namespace DotNetris
{
    partial class LeaderboardForm
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
            NextBtn = new Button();
            PrevButton = new Button();
            Scores = new ListBox();
            PageLabel = new Label();
            ViewReplayBtn = new Button();
            SuspendLayout();
            // 
            // NextBtn
            // 
            NextBtn.Enabled = false;
            NextBtn.Location = new Point(211, 172);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new Size(30, 23);
            NextBtn.TabIndex = 0;
            NextBtn.Text = ">";
            NextBtn.UseVisualStyleBackColor = true;
            NextBtn.Click += NextBtn_Click;
            // 
            // PrevButton
            // 
            PrevButton.Enabled = false;
            PrevButton.Location = new Point(12, 172);
            PrevButton.Name = "PrevButton";
            PrevButton.Size = new Size(25, 23);
            PrevButton.TabIndex = 1;
            PrevButton.Text = "<";
            PrevButton.UseVisualStyleBackColor = true;
            PrevButton.Click += PrevButton_Click;
            // 
            // Scores
            // 
            Scores.FormattingEnabled = true;
            Scores.ItemHeight = 15;
            Scores.Location = new Point(12, 12);
            Scores.Name = "Scores";
            Scores.Size = new Size(229, 154);
            Scores.TabIndex = 2;
            // 
            // PageLabel
            // 
            PageLabel.AutoSize = true;
            PageLabel.Location = new Point(102, 203);
            PageLabel.Name = "PageLabel";
            PageLabel.Size = new Size(42, 15);
            PageLabel.TabIndex = 3;
            PageLabel.Text = "Page 1";
            // 
            // ViewReplayBtn
            // 
            ViewReplayBtn.Location = new Point(87, 172);
            ViewReplayBtn.Name = "ViewReplayBtn";
            ViewReplayBtn.Size = new Size(75, 23);
            ViewReplayBtn.TabIndex = 4;
            ViewReplayBtn.Text = "View";
            ViewReplayBtn.UseVisualStyleBackColor = true;
            ViewReplayBtn.Click += ViewReplayBtn_Click;
            // 
            // LeaderboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 227);
            Controls.Add(ViewReplayBtn);
            Controls.Add(PageLabel);
            Controls.Add(Scores);
            Controls.Add(PrevButton);
            Controls.Add(NextBtn);
            Name = "LeaderboardForm";
            Text = "Leaderboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button NextBtn;
        private Button PrevButton;
        private ListBox Scores;
        private Label PageLabel;
        private Button ViewReplayBtn;
    }
}