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

namespace DotNetris
{
    public partial class SinglePlayerSettingsForm : Form
    {

        public SinglePlayerSettingsForm()
        {
            InitializeComponent(); ;
            ExitBtn3.Click += new EventHandler(ExitBtn3_Click);
            EnableReplayCheckbox.Enabled = ClientSingleton.IsLoggedIn;
            EnableReplayCheckbox.Checked = ClientSingleton.IsLoggedIn;
        }

        private void DotNetrisLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Again????!!!!!");
        }

        private void ExitBtn3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I have no Idea how you found me.");
        }

        private void HardSettingsBtn_Click(object sender, EventArgs e)
        {
            RunGame(Difficulty.Hard);
        }

        private void NormalSettingsBtn_Click(object sender, EventArgs e)
        {
            RunGame(Difficulty.Normal);
        }

        private void EasySettingBtn_Click(object sender, EventArgs e)
        {
            RunGame(Difficulty.Easy);
        }

        private void RunGame(Difficulty dif)
        {
            if (EnableReplayCheckbox.Checked)
            {
                RunOnlineGame(dif);
            }
            else
            {
                RunOfflineGame(dif);
            }
        }

        private void RunOnlineGame(Difficulty dif)
        {
            // fetch the game token
            SignedGameSettings settings;
            try
            {
                settings = ClientSingleton.client!.RequestGame(
                    new GameSettings()
                    {
                        Difficulty = dif.ToNetwork()
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Game game = new Game(settings);
            Hide();
            new SinglePlayerInGame(game).ShowDialog();
            Show();
        }
        private void RunOfflineGame(Difficulty dif)
        {
            Game game = new Game(dif);
            Hide();
            new SinglePlayerInGame(game).ShowDialog();
            Show();
        }
    }
}
