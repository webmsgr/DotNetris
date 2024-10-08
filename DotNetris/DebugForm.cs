﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetris
{
    public partial class DebugForm : Form
    {
        private Game game;

        private ulong GameTickCount = 0;
        public DebugForm()
        {
            InitializeComponent();
            Reset();

            AutoTickTimer.Enabled = true;
            AutoTickTimer.Interval = 1000 / Game.Tickrate;
            AutoTickRate.Maximum = Game.Tickrate;
            AutoTickRate.Value = Game.Tickrate;
            SetYBox.Maximum = GameBoard.Height - 1;
            setXBox.Maximum = GameBoard.Width - 1;
            var colors = new[]
            {
                Color.Empty,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Green,
                Color.Blue,
                Color.Purple
            };
            SetColorBox.DataSource = colors.Clone();
            FillRowColor.DataSource = colors.Clone();
            FillAllColor.DataSource = colors.Clone();
            ClearRowSelect.Maximum = GameBoard.Height - 1;



        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Right:
                    game.SetInput(Inputs.RotateRight);
                    break;
                case Keys.Left:
                    game.SetInput(Inputs.RotateLeft);
                    break;
                case Keys.W:
                    game.SetInput(Inputs.Up);
                    break;
                case Keys.D:
                    game.SetInput(Inputs.Right);
                    break;
                case Keys.A:
                    game.SetInput(Inputs.Left);
                    break;
                case Keys.S:
                    game.SetInput(Inputs.Down);
                    break;
            }


        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.Right:
                    game.ClearInput(Inputs.RotateRight);
                    break;
                case Keys.Left:
                    game.ClearInput(Inputs.RotateLeft);
                    break;
                case Keys.W:
                    game.ClearInput(Inputs.Up);
                    break;
                case Keys.D:
                    game.ClearInput(Inputs.Right);
                    break;
                case Keys.A:
                    game.ClearInput(Inputs.Left);
                    break;
                case Keys.S:
                    game.ClearInput(Inputs.Down);
                    break;
            }


        }

        private void OnTick(object? sender, Inputs t)
        {
            GameTickCount += 1;
            TickLabel.Text = $"{GameTickCount} Ticks: {t}";
        }

        private void OnLose(object sender, object? data)
        {
            AutoTickEnabled.Checked = false;
            MessageBox.Show($"You lose! Your score: {game.Score:N0}");
            Reset();

        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            game.Board.Set((int)setXBox.Value, (int)SetYBox.Value, (Color)SetColorBox.SelectedItem!);
            Render.Draw();
        }

        private void FillRowBtn_Click(object sender, EventArgs e)
        {
            game.Board.GetRow((int)FillRowY.Value).Fill((Color)FillRowColor.SelectedItem!);
            Render.Draw();
        }

        private void FillAllBtn_Click(object sender, EventArgs e)
        {
            game.Board.GetBoard().Fill((Color)FillAllColor.SelectedItem!);
            Render.Draw();
        }

        private void Render_Click(object sender, EventArgs e)
        {
            MouseEventArgs e2 = (MouseEventArgs)e;
            var target = e2.Location;
            var x = target.X / GameBoardRender.TileSize;
            var y = target.Y / GameBoardRender.TileSize;

            SetYBox.Value = y;
            setXBox.Value = x;
            FillRowY.Value = y;
            ClearRowSelect.Value = y;
        }

        private void AutoTickTimer_Tick(object sender, EventArgs e)
        {
            if (AutoTickEnabled.Checked)
            {
                game.Tick();
                Render.Draw();
            }
        }

        private void OnScoreUpdate(object sender, ulong score)
        {
            ScoreLabel.Text = $"Score: {score:N0}";

        }

        private void AutoTickRate_ValueChanged(object sender, EventArgs e)
        {
            AutoTickTimer.Interval = 1000 / (int)AutoTickRate.Value;
        }

        private void TickBtn_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < TickCount.Value; i++)
            {
                game.Tick();
            }
            Render.Draw();
        }

        private void Reset()
        {
            game = new Game("hollowheart".GetHashCode(), Difficulty.Normal);
            game.OnTick += OnTick;
            game.OnLose += OnLose;
            game.OnScoreUpdate += OnScoreUpdate;
            Render.game = game;
            Render.Draw();
            TickLabel.Text = "0 Ticks";
            GameTickCount = 0;
            ScoreLabel.Text = "Score: 0";
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void ClearRowBtn_Click(object sender, EventArgs e)
        {
            game.Board.ClearLine((int)ClearRowSelect.Value);
            Render.Draw();
        }
    }
}
