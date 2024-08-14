namespace DotNetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
