using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetris.Network.Protocol;

namespace DotNetris
{
    public partial class ReplayForm : Form
    {
        private SerializedReplay _replay;
        private Game _game;
        private int _input = 0;
        public ReplayForm(SerializedReplay replay)
        {
            _replay = replay;
            _input = 0;
            _game = new Game(replay.Settings);
            InitializeComponent();
            timer1.Interval = 1000 / Game.Tickrate;
            gameBoardRender1.game = _game;
            gameBoardRender1.Draw();
            seekPos.Maximum = _replay.Replay.Length;
            UpdateStats();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Pause();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Step();
        }

        private void Step()
        {
            if (_input >= _replay.Replay.Length)
            {
                Pause();
                return;
            }
            _game.Inputs = (Inputs)_replay.Replay[_input];
            _input++;
            _game.Tick();
            gameBoardRender1.Draw();
            UpdateStats();
        }

        private void Play()
        {
            PlayPause.Text = "Pause";
            timer1.Enabled = true;
        }
        private void Pause()
        {
            timer1.Enabled = false;
            PlayPause.Text = "Play";
        }

        private void Restart()
        {
            Pause();
            _game = new Game(_replay.Settings);
            gameBoardRender1.game = _game;
            _input = 0;
            gameBoardRender1.Draw();
            UpdateStats();
        }

        private void Seek(int position)
        {
            Restart();
            for (int i = 0; i < position; i++)
            {
                _game.Inputs = (Inputs)_replay.Replay[_input];
                _input++;
                _game.Tick();
            }
            UpdateStats();
            gameBoardRender1.Draw();
        }


        private void UpdateStats()
        {
            ScoreStat.Text = $"Score: {_game.Score}";
            LevelStat.Text = $"Level: {_game.Level}";
            ProgressStat.Text = $"Progress: {_input}/{_replay.Replay.Length}";
        }

        private void PlayPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }

        private void SeekBtn_Click(object sender, EventArgs e)
        {
            Seek((int)seekPos.Value);
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }
}
