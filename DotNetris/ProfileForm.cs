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


        private void ExitBtn5_Click(object sender, EventArgs e)
        {
            // Create an instance of the Main Menu form
            MainMenuForm mainMenu = new MainMenuForm();

            // Show the Main Menu form
            mainMenu.Show();

            // Close the current form
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(ClientSingleton.client!.DeleteAccount(DeletePasswordBox.Text));
                ExitBtn5_Click(sender, e); // trick it into exiting
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(ClientSingleton.client!.ChangePassword(ChangePasswordOld.Text, ChangePasswordNew.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
