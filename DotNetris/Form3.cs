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
    public partial class SettingForm : Form
    {
        private MainMenuForm mainMenu;
        public SettingForm(MainMenuForm mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            ExitBtn6.Click += new EventHandler(ExitBtn6_Click);
        }

        private void ExitBtn6_Click(object sender, EventArgs e)
        {
            

            // Show the Main Menu form
            mainMenu.Show();

            // Close the current form
            this.Close();
        }
    }
}
