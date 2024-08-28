using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetris.Configuration;
using DotNetris.Network.Client;

namespace DotNetris
{
    public partial class LoginRegisterForm : Form
    {
        private MainMenuForm mainMenu;

        private ConfigEntry savedUsername = new ConfigEntry("savedUsername", "");
        private ConfigEntry savedPassword = new ConfigEntry("savedPassword", "");

        public LoginRegisterForm(MainMenuForm mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            ExitBtn4.Click += new EventHandler(ExitBtn4_Click);
            if (savedUsername.Value != "")
            {
                LoginUsername.Text = savedUsername.Value;
                LoginPassword.Text = savedPassword.Value;
                StayLoggedIn.Checked = true;
            }

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

        private void LoginBtn1_Click(object sender, EventArgs e)
        {
            if (StayLoggedIn.Checked)
            {
                savedUsername.Value = LoginUsername.Text;
                savedPassword.Value = LoginPassword.Text;
            }
            else
            {
                savedUsername.Value = "";
                savedPassword.Value = "";
            }

            try
            {
                MessageBox.Show(ClientSingleton.client!.Login(LoginUsername.Text, LoginPassword.Text));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StayLoggedIn_CheckedChanged(object sender, EventArgs e)
        {
            if (!StayLoggedIn.Checked)
            {
                savedPassword.Value = "";
                savedUsername.Value = "";
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (RegisterPassword.Text != RegisterPasswordConfirm.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            try
            {
                MessageBox.Show(ClientSingleton.client!.Register(RegisterUsername.Text, RegisterPassword.Text));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
