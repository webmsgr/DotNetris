using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using DotNetris.Network.Client;
using DotNetris.Network.Protocol;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace DotNetris
{

    public partial class LeaderboardForm : Form
    {

        class ReplayEntryDisplay(ReplayEntry inner)
        {
            internal ReplayEntry inner = inner;

            public override string ToString()
            {
                return $"[{inner.Difficulty}] {inner.Score:N0} by {inner.Username}";
            }
        }

        private ReplayEntry[] _scores = new ReplayEntry[] { };
        private int page = 0;
        private int PageSize;

        public LeaderboardForm()
        {
            InitializeComponent();
            //int lineHeight = TextRenderer.MeasureText("X", this.Scores.Font).Height;
            PageSize = Scores.ClientSize.Height / Scores.ItemHeight; //probably not completely accurate
            LoadScores();
        }

        private void LoadScores()
        {
            try
            {
                var start = page * PageSize;
                var end = start + PageSize + 1;
                var c = ClientSingleton.client!.FetchLeaderboard(page * PageSize, end);
                if (c.Length == PageSize + 1)
                {
                    NextBtn.Enabled = true;
                    c = c[..^1];
                }
                else
                {
                    NextBtn.Enabled = false;
                }
                PrevButton.Enabled = page > 0;
                _scores = c;
                Scores.DataSource = new List<ReplayEntryDisplay>(
                    _scores.Select(i => new ReplayEntryDisplay(i))
                    );
                PageLabel.Text = $"Page {page + 1}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            page++;
            LoadScores();
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            page--;
            LoadScores();
        }

        private void ViewReplayBtn_Click(object sender, EventArgs e)
        {
            if (Scores.SelectedItem is ReplayEntryDisplay r)
            {
                var replay = ClientSingleton.client!.DownloadReplay(r.inner.Id);
                var form = new ReplayForm(replay);
                Hide();
                form.ShowDialog();
                Show();
            }
        }
    }
}
