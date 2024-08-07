namespace DotNetris
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        public Form1()
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
