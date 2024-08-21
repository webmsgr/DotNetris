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
    public partial class ProfileForm : Form
    {
        private MainMenuForm mainMenu;
        public ProfileForm(MainMenuForm mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            ExitBtn5.Click += new EventHandler(ExitBtn5_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn5_Click(object sender, EventArgs e)
        {
            // Create an instance of the Main Menu form
            MainMenuForm mainMenu = new MainMenuForm();

            // Show the Main Menu form
            mainMenu.Show();

            // Close the current form
            this.Close();
        }

        
    }
}
