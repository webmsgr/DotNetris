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
    public partial class SinglePlayerSettingsForm : Form
    {
        public SinglePlayerSettingsForm()
        {
            InitializeComponent();
            ExitBtn3.Click += new EventHandler(ExitBtn3_Click);
        }

        private void DotNetrisLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Again????!!!!!");
        }

        private void ExitBtn3_Click(object sender, EventArgs e)
        {
            // Create an instance of the Main Menu form
            MainMenuForm mainMenu = new MainMenuForm();

            // Show the Main Menu form
            mainMenu.Show();

            // Close the current form
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I have no Idea how you found me.");
        }

        private void HardSettingsBtn_Click(object sender, EventArgs e)
        {
            Game game = new Game(Difficulty.Hard);
            Hide();
            new SinglePlayerInGame(game).ShowDialog();
            Show();
        }

        private void NormalSettingsBtn_Click(object sender, EventArgs e)
        {
            Game game = new Game(Difficulty.Normal);
            Hide();
            new SinglePlayerInGame(game).ShowDialog();
            Show();
        }

        private void EasySettingBtn_Click(object sender, EventArgs e)
        {
            Game game = new Game(Difficulty.Easy);
            game.PieceDropSpeed.Interval = Game.Tickrate;
            Hide();
            new SinglePlayerInGame(game).ShowDialog();
            Show();
        }
    }
}
