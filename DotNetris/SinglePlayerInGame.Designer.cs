namespace DotNetris
{
    partial class SinglePlayerInGame
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
            GameTick = new System.Windows.Forms.Timer(components);
            ScoreLabel = new Label();
            label1 = new Label();
            Next1 = new PieceRender();
            Next2 = new PieceRender();
            Next3 = new PieceRender();
            label2 = new Label();
            SuspendLayout();
            // 
            // gameBoardRender1
            // 
            gameBoardRender1.Location = new Point(264, 12);
            gameBoardRender1.Name = "gameBoardRender1";
            gameBoardRender1.Size = new Size(288, 608);
            gameBoardRender1.TabIndex = 0;
            gameBoardRender1.Text = "gameBoardRender1";
            // 
            // GameTick
            // 
            GameTick.Enabled = true;
            GameTick.Tick += GameTick_Tick;
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.Location = new Point(558, 27);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new Size(48, 30);
            ScoreLabel.TabIndex = 1;
            ScoreLabel.Text = "Score: 0\r\nLevel: 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 54);
            label1.Name = "label1";
            label1.Size = new Size(169, 75);
            label1.TabIndex = 3;
            label1.Text = "Controls:\r\nA/D: Move piece left and right\r\nW: unimplemented\r\nS: Drop piece faster\r\nQ/E: Rotate piece left and right\r\n";
            // 
            // Next1
            // 
            Next1.Location = new Point(558, 90);
            Next1.Name = "Next1";
            Next1.Size = new Size(96, 96);
            Next1.TabIndex = 4;
            Next1.Text = "pieceRender1";
            // 
            // Next2
            // 
            Next2.Location = new Point(558, 192);
            Next2.Name = "Next2";
            Next2.Size = new Size(96, 96);
            Next2.TabIndex = 5;
            Next2.Text = "pieceRender2";
            // 
            // Next3
            // 
            Next3.Location = new Point(558, 294);
            Next3.Name = "Next3";
            Next3.Size = new Size(96, 96);
            Next3.TabIndex = 6;
            Next3.Text = "pieceRender3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(558, 72);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 7;
            label2.Text = "Next";
            // 
            // SinglePlayerInGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 642);
            Controls.Add(label2);
            Controls.Add(Next3);
            Controls.Add(Next2);
            Controls.Add(Next1);
            Controls.Add(label1);
            Controls.Add(ScoreLabel);
            Controls.Add(gameBoardRender1);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "SinglePlayerInGame";
            Text = "Single Player";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GameBoardRender gameBoardRender1;
        private System.Windows.Forms.Timer GameTick;
        private Label ScoreLabel;
        private Label label1;
        private PieceRender Next1;
        private PieceRender Next2;
        private PieceRender Next3;
        private Label label2;
    }
}