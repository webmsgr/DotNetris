namespace DotNetris
{
    public partial class MainMenuForm : Form
    {
        MultiplayerForm form2 = new MultiplayerForm();
        public MainMenuForm()
        {
            InitializeComponent();
            MultiPlayerBtn.Click += new EventHandler(MulitPlayerBtn_Click);
        }
        private void MulitPlayerBtn_Click(object sender, EventArgs e)
        {
            form2.Show();

            this.Hide();

        }

        private void DotNetrisLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Found me!");
        }
    }
}
