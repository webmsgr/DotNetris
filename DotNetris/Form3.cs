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
using DotNetris.Network;
using DotNetris.Network.Client;

namespace DotNetris
{
    public partial class SettingForm : Form
    {
        private MainMenuForm mainMenu;

        private ConfigEntry hostConfig = new ConfigEntry("ServerHost", "");
        private ConfigEntry portConfig = new ConfigEntry("ServerPort", "8080");
        private ConfigEntry securityConfig = new ConfigEntry("SecurityLevel", "None");
        private ConfigEntry passwordConfig = new ConfigEntry("ServerPassword", "");




        public SettingForm(MainMenuForm mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            ExitBtn6.Click += new EventHandler(ExitBtn6_Click);
            Load();
        }

        private void ExitBtn6_Click(object sender, EventArgs e)
        {


            // Show the Main Menu form
            mainMenu.Show();

            // Close the current form
            this.Close();
        }

        private void Load()
        {
            HostBox.Text = hostConfig.Value;
            if (ushort.TryParse(portConfig.Value, out ushort result))
            {
                PortBox.Value = result;
            }
            else
            {
                PortBox.Value = 8080;
            }
            switch (securityConfig.Value)
            {
                case ("None"):
                    NoneSecurityRadio.Checked = true;
                    break;
                case ("Password"):
                    PasswordSecurity.Checked = true;
                    PasswordBox.Enabled = true;
                    break;
                case ("TLS"):
                    TLSSecurity.Checked = true;
                    break;
                default:
                    NoneSecurityRadio.Checked = true;
                    break;
            }
            PasswordBox.Text = passwordConfig.Value;
        }

        private void Save()
        {
            hostConfig.Value = HostBox.Text;
            portConfig.Value = PortBox.Value.ToString();
            if (NoneSecurityRadio.Checked)
            {
                securityConfig.Value = "None";
            }
            else if (PasswordSecurity.Checked)
            {
                securityConfig.Value = "Password";
            }
            else if (TLSSecurity.Checked)
            {
                securityConfig.Value = "TLS";
            }
            passwordConfig.Value = PasswordBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void PasswordSecurity_CheckedChanged(object sender, EventArgs e)
        {
            PasswordBox.Enabled = PasswordSecurity.Checked;
        }

        private void SaveAndConnectBtn_Click(object sender, EventArgs e)
        {
            Save();
            if (ClientSingleton.IsConnecteed)
            {
                ClientSingleton.client?.Close();
            }
            // oh boy.
            SecurityLevel level;
            if (NoneSecurityRadio.Checked)
            {
                level = SecurityLevel.None;
            }
            else if (PasswordSecurity.Checked)
            {
                level = SecurityLevel.Password;
            }
            else if (TLSSecurity.Checked)
            {
                level = SecurityLevel.TLS;
            }
            else
            {
                level = SecurityLevel.None;
            }

            var conf = new ClientConfig()
            {
                host = HostBox.Text,
                port = (ushort)PortBox.Value,
                security = level,
                password = Encoding.UTF8.GetBytes(PasswordBox.Text)
            };
            try
            {
                var client = new Client(conf);
                client.Connect();
                ClientSingleton.client = client;
                MessageBox.Show("Successfully connected to server!");
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server: " + ex.Message);
            }
        }
    }
}
