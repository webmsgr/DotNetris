namespace DotNetris
{
    partial class DebugForm
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
            Render = new GameBoardRender();
            setXBox = new NumericUpDown();
            SetYBox = new NumericUpDown();
            SetColorBox = new ComboBox();
            SetButton = new Button();
            FillRowBtn = new Button();
            FillRowColor = new ComboBox();
            FillRowY = new NumericUpDown();
            FillAllBtn = new Button();
            FillAllColor = new ComboBox();
            TickBtn = new Button();
            TickCount = new NumericUpDown();
            AutoTickEnabled = new CheckBox();
            AutoTickRate = new NumericUpDown();
            AutoTickTimer = new System.Windows.Forms.Timer(components);
            TickLabel = new Label();
            ResetBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)setXBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SetYBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FillRowY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TickCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AutoTickRate).BeginInit();
            SuspendLayout();
            // 
            // Render
            // 
            Render.Location = new Point(523, 23);
            Render.Name = "Render";
            Render.Size = new Size(289, 609);
            Render.TabIndex = 0;
            Render.Text = "gameBoardRender1";
            Render.Click += Render_Click;
            // 
            // setXBox
            // 
            setXBox.Location = new Point(66, 109);
            setXBox.Name = "setXBox";
            setXBox.Size = new Size(120, 23);
            setXBox.TabIndex = 1;
            // 
            // SetYBox
            // 
            SetYBox.Location = new Point(192, 109);
            SetYBox.Name = "SetYBox";
            SetYBox.Size = new Size(120, 23);
            SetYBox.TabIndex = 2;
            // 
            // SetColorBox
            // 
            SetColorBox.FormattingEnabled = true;
            SetColorBox.Location = new Point(318, 109);
            SetColorBox.Name = "SetColorBox";
            SetColorBox.Size = new Size(121, 23);
            SetColorBox.TabIndex = 3;
            // 
            // SetButton
            // 
            SetButton.Location = new Point(442, 109);
            SetButton.Name = "SetButton";
            SetButton.Size = new Size(75, 23);
            SetButton.TabIndex = 4;
            SetButton.Text = "Set";
            SetButton.UseVisualStyleBackColor = true;
            SetButton.Click += SetButton_Click;
            // 
            // FillRowBtn
            // 
            FillRowBtn.Location = new Point(442, 182);
            FillRowBtn.Name = "FillRowBtn";
            FillRowBtn.Size = new Size(75, 23);
            FillRowBtn.TabIndex = 5;
            FillRowBtn.Text = "Fill Row";
            FillRowBtn.UseVisualStyleBackColor = true;
            FillRowBtn.Click += FillRowBtn_Click;
            // 
            // FillRowColor
            // 
            FillRowColor.FormattingEnabled = true;
            FillRowColor.Location = new Point(318, 182);
            FillRowColor.Name = "FillRowColor";
            FillRowColor.Size = new Size(121, 23);
            FillRowColor.TabIndex = 6;
            // 
            // FillRowY
            // 
            FillRowY.Location = new Point(192, 184);
            FillRowY.Name = "FillRowY";
            FillRowY.Size = new Size(120, 23);
            FillRowY.TabIndex = 7;
            // 
            // FillAllBtn
            // 
            FillAllBtn.Location = new Point(442, 241);
            FillAllBtn.Name = "FillAllBtn";
            FillAllBtn.Size = new Size(75, 23);
            FillAllBtn.TabIndex = 8;
            FillAllBtn.Text = "Fill All";
            FillAllBtn.UseVisualStyleBackColor = true;
            FillAllBtn.Click += FillAllBtn_Click;
            // 
            // FillAllColor
            // 
            FillAllColor.FormattingEnabled = true;
            FillAllColor.Location = new Point(318, 241);
            FillAllColor.Name = "FillAllColor";
            FillAllColor.Size = new Size(121, 23);
            FillAllColor.TabIndex = 9;
            // 
            // TickBtn
            // 
            TickBtn.Location = new Point(156, 486);
            TickBtn.Name = "TickBtn";
            TickBtn.Size = new Size(75, 23);
            TickBtn.TabIndex = 10;
            TickBtn.Text = "Tick";
            TickBtn.UseVisualStyleBackColor = true;
            TickBtn.Click += TickBtn_Click;
            // 
            // TickCount
            // 
            TickCount.Location = new Point(30, 486);
            TickCount.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            TickCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TickCount.Name = "TickCount";
            TickCount.Size = new Size(120, 23);
            TickCount.TabIndex = 11;
            TickCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // AutoTickEnabled
            // 
            AutoTickEnabled.AutoSize = true;
            AutoTickEnabled.Location = new Point(156, 515);
            AutoTickEnabled.Name = "AutoTickEnabled";
            AutoTickEnabled.Size = new Size(73, 19);
            AutoTickEnabled.TabIndex = 12;
            AutoTickEnabled.Text = "AutoTick";
            AutoTickEnabled.UseVisualStyleBackColor = true;
            // 
            // AutoTickRate
            // 
            AutoTickRate.Location = new Point(30, 511);
            AutoTickRate.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            AutoTickRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            AutoTickRate.Name = "AutoTickRate";
            AutoTickRate.Size = new Size(120, 23);
            AutoTickRate.TabIndex = 13;
            AutoTickRate.Value = new decimal(new int[] { 30, 0, 0, 0 });
            AutoTickRate.ValueChanged += AutoTickRate_ValueChanged;
            // 
            // AutoTickTimer
            // 
            AutoTickTimer.Tick += AutoTickTimer_Tick;
            // 
            // TickLabel
            // 
            TickLabel.AutoSize = true;
            TickLabel.Location = new Point(30, 537);
            TickLabel.Name = "TickLabel";
            TickLabel.Size = new Size(42, 15);
            TickLabel.TabIndex = 14;
            TickLabel.Text = "0 Ticks";
            // 
            // ResetBtn
            // 
            ResetBtn.Location = new Point(442, 64);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(75, 23);
            ResetBtn.TabIndex = 15;
            ResetBtn.Text = "Reset";
            ResetBtn.UseVisualStyleBackColor = true;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // DebugForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 664);
            Controls.Add(ResetBtn);
            Controls.Add(TickLabel);
            Controls.Add(AutoTickRate);
            Controls.Add(AutoTickEnabled);
            Controls.Add(TickCount);
            Controls.Add(TickBtn);
            Controls.Add(FillAllColor);
            Controls.Add(FillAllBtn);
            Controls.Add(FillRowY);
            Controls.Add(FillRowColor);
            Controls.Add(FillRowBtn);
            Controls.Add(SetButton);
            Controls.Add(SetColorBox);
            Controls.Add(SetYBox);
            Controls.Add(setXBox);
            Controls.Add(Render);
            KeyPreview = true;
            Name = "DebugForm";
            Text = "Debug";
            ((System.ComponentModel.ISupportInitialize)setXBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)SetYBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)FillRowY).EndInit();
            ((System.ComponentModel.ISupportInitialize)TickCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)AutoTickRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GameBoardRender Render;
        private NumericUpDown setXBox;
        private NumericUpDown SetYBox;
        private ComboBox SetColorBox;
        private Button SetButton;
        private Button FillRowBtn;
        private ComboBox FillRowColor;
        private NumericUpDown FillRowY;
        private Button FillAllBtn;
        private ComboBox FillAllColor;
        private Button TickBtn;
        private NumericUpDown TickCount;
        private CheckBox AutoTickEnabled;
        private NumericUpDown AutoTickRate;
        private System.Windows.Forms.Timer AutoTickTimer;
        private Label TickLabel;
        private Button ResetBtn;
    }
}