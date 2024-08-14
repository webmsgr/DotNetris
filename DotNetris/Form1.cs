namespace DotNetris
{
    public partial class MainMenuForm : Form
    {
        MultiplayerForm form2 = new MultiplayerForm();
        SinglePlayerSettingsForm settingsForm = new SinglePlayerSettingsForm();
        LoginRegisterForm loginRegisterForm = new LoginRegisterForm();
        ProfileForm frm = new ProfileForm();
        SettingForm settingForm = new SettingForm();

        public MainMenuForm()
        {
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
            form2.Show();

            this.Hide();

        }

        private void SinglePlayerBtn_Click(object sender,EventArgs e) 
        {
            
            settingsForm.Show();

            this.Hide(); 

        }

        private void LogInRegBtn_Click(object sender, EventArgs e) 
        {
            loginRegisterForm.Show();

            this.Hide();
        }

        private void ProfileBtn_Click(object sender, EventArgs e) 
        { 
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
            Application.Exit();
        }

        private void DotNetrisLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Found me!");
        }
    }
}
