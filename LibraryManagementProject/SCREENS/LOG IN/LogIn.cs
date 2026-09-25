using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementProject
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            // 1. Create the manager
            LibraryManagementProject.BLL.UserManager userManager = new LibraryManagementProject.BLL.UserManager();

            // 2. Pass the text box values to the manager
            string result = userManager.Login(txtEmail.Text, txtPassword.Text);

            // 3. Act on the result
            if (result == "Success")
            {
                // Open the Main Dashboard and hide the Login Screen
                Dashboard form2 = new Dashboard();
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                // Show the error message (e.g., "Invalid Username or Password")
                MessageBox.Show(result, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed was the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // This stops Windows from making that annoying "Ding!" error sound
                e.SuppressKeyPress = true;

                // Move the blinking cursor to the next text box
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed was the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // This stops Windows from making that annoying "Ding!" error sound
                e.SuppressKeyPress = true;

                // Move the blinking cursor to the next button
                btnLogIn.Focus();
            }
        }
    }
}
