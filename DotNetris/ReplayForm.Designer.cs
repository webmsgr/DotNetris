namespace DotNetris
{
    partial class ReplayForm
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
            components = new System.ComponentModel.Container();
            gameBoardRender1 = new GameBoardRender();
            timer1 = new System.Windows.Forms.Timer(components);
            PlayPause = new Button();
            groupBox1 = new GroupBox();
            ProgressStat = new Label();
            LevelStat = new Label();
            ScoreStat = new Label();
            seekPos = new NumericUpDown();
            groupBox2 = new GroupBox();
            RestartButton = new Button();
            SeekBtn = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)seekPos).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // gameBoardRender1
            // 
            gameBoardRender1.Location = new Point(12, 12);
            gameBoardRender1.Name = "gameBoardRender1";
            gameBoardRender1.Size = new Size(288, 608);
            gameBoardRender1.TabIndex = 0;
            gameBoardRender1.Text = "gameBoardRender1";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // PlayPause
            // 
            PlayPause.Location = new Point(6, 22);
            PlayPause.Name = "PlayPause";
            PlayPause.Size = new Size(112, 40);
            PlayPause.TabIndex = 1;
            PlayPause.Text = "Play";
            PlayPause.UseVisualStyleBackColor = true;
            PlayPause.Click += PlayPause_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ProgressStat);
            groupBox1.Controls.Add(LevelStat);
            groupBox1.Controls.Add(ScoreStat);
            groupBox1.Location = new Point(316, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(124, 72);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stats";
            // 
            // ProgressStat
            // 
            ProgressStat.AutoSize = true;
            ProgressStat.Location = new Point(6, 49);
            ProgressStat.Name = "ProgressStat";
            ProgressStat.Size = new Size(75, 15);
            ProgressStat.TabIndex = 2;
            ProgressStat.Text = "Progress: 0/0";
            // 
            // LevelStat
            // 
            LevelStat.AutoSize = true;
            LevelStat.Location = new Point(6, 34);
            LevelStat.Name = "LevelStat";
            LevelStat.Size = new Size(46, 15);
            LevelStat.TabIndex = 1;
            LevelStat.Text = "Level: 1";
            // 
            // ScoreStat
            // 
            ScoreStat.AutoSize = true;
            ScoreStat.Location = new Point(6, 19);
            ScoreStat.Name = "ScoreStat";
            ScoreStat.Size = new Size(48, 15);
            ScoreStat.TabIndex = 0;
            ScoreStat.Text = "Score: 0";
            // 
            // seekPos
            // 
            seekPos.Location = new Point(6, 68);
            seekPos.Name = "seekPos";
            seekPos.Size = new Size(75, 23);
            seekPos.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RestartButton);
            groupBox2.Controls.Add(SeekBtn);
            groupBox2.Controls.Add(PlayPause);
            groupBox2.Controls.Add(seekPos);
            groupBox2.Location = new Point(316, 485);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(124, 135);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Controls";
            // 
            // RestartButton
            // 
            RestartButton.Location = new Point(6, 97);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(112, 23);
            RestartButton.TabIndex = 5;
            RestartButton.Text = "Restart";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Click += RestartButton_Click;
            // 
            // SeekBtn
            // 
            SeekBtn.Location = new Point(87, 68);
            SeekBtn.Name = "SeekBtn";
            SeekBtn.Size = new Size(31, 23);
            SeekBtn.TabIndex = 4;
            SeekBtn.Text = "Go";
            SeekBtn.UseVisualStyleBackColor = true;
            SeekBtn.Click += SeekBtn_Click;
            // 
            // ReplayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 637);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gameBoardRender1);
            Name = "ReplayForm";
            Text = "ReplayForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)seekPos).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GameBoardRender gameBoardRender1;
        private System.Windows.Forms.Timer timer1;
        private Button PlayPause;
        private GroupBox groupBox1;
        private Label ProgressStat;
        private Label LevelStat;
        private Label ScoreStat;
        private NumericUpDown seekPos;
        private GroupBox groupBox2;
        private Button RestartButton;
        private Button SeekBtn;
    }
}