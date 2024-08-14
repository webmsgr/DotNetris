﻿using System;
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
        public SettingForm()
        {
            InitializeComponent();
            ExitBtn6.Click += new EventHandler(ExitBtn6_Click);
        }

        private void ExitBtn6_Click(object sender, EventArgs e)
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
