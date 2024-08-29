using DotNetris.Network.Client;

namespace DotNetris
{
    public partial class MainMenuForm : Form
    {
        private MultiplayerForm form2;
        //private SinglePlayerSettingsForm settingsForm;
        private LoginRegisterForm loginRegisterForm;
        private ProfileForm frm;
        private SettingForm settingForm;

        public MainMenuForm()
        {
            form2 = new MultiplayerForm(this);
            //settingsForm = new SinglePlayerSettingsForm(this);
            loginRegisterForm = new LoginRegisterForm(this);
            frm = new ProfileForm(this);
            settingForm = new SettingForm(this);

            InitializeComponent();
            MultiPlayerBtn.Click += new EventHandler(MulitPlayerBtn_Click);
            SinglePlayerBtn.Click += new EventHandler(SinglePlayerBtn_Click);
            LogInRegBtn.Click += new EventHandler(LogInRegBtn_Click);
            ProfileBtn.Click += new EventHandler(ProfileBtn_Click);
            SettingBtn.Click += new EventHandler(SettingBtn_Click);
            ExitBtn.Click += new EventHandler(ExitBtn_Click);


        }

        private void ProfileBtn_Click1(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExitBtn_Click1(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MulitPlayerBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implmented.");
            return;
            form2.Show();

            this.Hide();

        }

        private void SinglePlayerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SinglePlayerSettingsForm().ShowDialog();

            this.Show();

        }

        private void LogInRegBtn_Click(object sender, EventArgs e)
        {

            if (!ClientSingleton.IsConnecteed)
            {
                MessageBox.Show("Not connected to a server! See settings");
                return;
            }

            if (ClientSingleton.IsLoggedIn)
            {
                MessageBox.Show("Already logged in!");
                return;
            }

            loginRegisterForm.Show();

            this.Hide();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            if (!ClientSingleton.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to view your profile!");
                return;
            }
            frm.Show();

            this.Hide();
        }

        private void SettingBtn_Click(object sender, EventArgs e)
        {
            settingForm.Show();

            this.Hide();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DotNetrisLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Found me!");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Alt | Keys.D))
            {
                new DebugForm().ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DebugForm().ShowDialog();
        }

        private void LeaderboardBtn_Click(object sender, EventArgs e)
        {
            if (!ClientSingleton.IsConnecteed)
            {
                MessageBox.Show("You must be connected to a server to view the leaderboards!");
                return;
            }
            var form = new LeaderboardForm();
            Hide();
            form.ShowDialog();
            Show();

        }
    }
}
