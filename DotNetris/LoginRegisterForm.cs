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
    public partial class LoginRegisterForm : Form
    {
        public LoginRegisterForm()
        {
            InitializeComponent();
            ExitBtn4.Click += new EventHandler(ExitBtn4_Click);
        }

        private void ExitBtn4_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }


        private void LoginLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bet you clicked others before me~");
        }

        private void LoginRegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Create an instance of the Main Menu form
            MainMenuForm mainMenu = new MainMenuForm();

            // Show the Main Menu form
            mainMenu.Show();
        }
    }
}
