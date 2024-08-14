using System;
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

        }

        private void OnTick(object? sender, Inputs t)
        {
            GameTickCount += 1;
            TickLabel.Text = $"{GameTickCount} Ticks";
        }

        private void OnLose(object sender, object? data)
        {
            AutoTickEnabled.Checked = false;
            MessageBox.Show("You lose!");
            Reset();

        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            game.Board.Set((int)setXBox.Value, (int)SetYBox.Value, (Color)SetColorBox.SelectedItem!);
            Render.Invalidate();
        }

        private void FillRowBtn_Click(object sender, EventArgs e)
        {
            game.Board.GetRow((int)FillRowY.Value).Fill((Color)FillRowColor.SelectedItem!);
            Render.Invalidate();
        }

        private void FillAllBtn_Click(object sender, EventArgs e)
        {
            game.Board.GetBoard().Fill((Color)FillAllColor.SelectedItem!);
            Render.Invalidate();
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
        }

        private void AutoTickTimer_Tick(object sender, EventArgs e)
        {
            if (AutoTickEnabled.Checked)
            {
                game.Tick();
                Render.Invalidate();
            }
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
            Render.Invalidate();
        }

        private void Reset()
        {
            game = new Game("hollowheart".GetHashCode());
            game.OnTick += OnTick;
            game.OnLose += OnLose;
            Render.game = game;
            Render.Invalidate();
            TickLabel.Text = "0 Ticks";
            GameTickCount = 0;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();   
        }
    }
}
