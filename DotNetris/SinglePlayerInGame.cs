using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetris.Network.Client;
using DotNetris.Network.Protocol;
using static System.Formats.Asn1.AsnWriter;

namespace DotNetris
{
    public partial class SinglePlayerInGame : Form
    {

        private Game game;
        public SinglePlayerInGame(Game game)
        {
            InitializeComponent();
            this.game = game;
            game.OnLose += OnLose;
            game.OnScoreUpdate += (object sender, ulong score) =>
            {
                ScoreLabel.Text = $"Score: {score:N0}\nLevel: {game.Level}\nDifficulty: {game.Difficulty}";
            };
            game.OnNewPiece += (object sender, EventArgs e) =>
            {
                Next1.CurrentPiece = game.Bag.Peek();
                Next2.CurrentPiece = game.Bag.PeekSecond();
                Next3.CurrentPiece = game.Bag.PeekThird();
            };

            ScoreLabel.Text = $"Score: 0\nLevel: {game.Level}\nDifficulty: {game.Difficulty}";
            gameBoardRender1.game = game;
            gameBoardRender1.Invalidate();
            Next1.CurrentPiece = game.Bag.Peek();
            Next2.CurrentPiece = game.Bag.PeekSecond();
            Next3.CurrentPiece = game.Bag.PeekThird();
            GameTick.Interval = 1000 / Game.Tickrate;
            GameTick.Enabled = true;

            // Next boxes
            switch (game.Difficulty)
            {
                case Difficulty.Easy:
                    break;
                case Difficulty.Normal:
                    // disable 2 and 3
                    Next2.Visible = false;
                    Next3.Visible = false;
                    break;
                case Difficulty.Hard:
                    // disable all 3
                    Next1.Visible = false;
                    Next2.Visible = false;
                    Next3.Visible = false;
                    break;
                default:
                    throw new NotImplementedException();
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            GameTick.Enabled = false; //
            Dispose(true); // bye
        }

        private void OnLose(object sender, object? data)
        {
            GameTick.Enabled = false;
            if (game.IsOnline && game.SignedGameSettings != null) 
            {
                // we can upload this game
                var res = MessageBox.Show($"You lose! Your score: {game.Score:N0}. Upload Replay?", "",
                    MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    // upload it
                    try
                    {
                        MessageBox.Show(ClientSingleton.client!.UploadReplay(game.SignedGameSettings, [.. game.Replay]));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show($"You lose! Your score: {game.Score:N0}");
            }

            Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.E:
                    game.SetInput(Inputs.RotateRight);
                    break;
                case Keys.Q:
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
                case Keys.E:
                    game.ClearInput(Inputs.RotateRight);
                    break;
                case Keys.Q:
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

        private void GameTick_Tick(object sender, EventArgs e)
        {
            game.Tick();
            gameBoardRender1.Draw();
        }
    }
}
