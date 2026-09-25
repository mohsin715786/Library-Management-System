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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void manageBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Clear whatever is currently inside the panel
            pnlContent.Controls.Clear();

            // 2. Create your new responsive screen
            Manage_Books_UI booksScreen = new Manage_Books_UI();

            // 3. Tell it to stretch and fill the panel perfectly
            booksScreen.Dock = DockStyle.Fill;

            // 4. Add it to the panel to display it!
            pnlContent.Controls.Add(booksScreen);
        }

        private void manageStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Clear whatever is currently inside the panel
            pnlContent.Controls.Clear();

            // 2. Create your new responsive screen
            Form4 studentsScreen = new Form4();

            // 3. Tell it to stretch and fill the panel perfectly
            studentsScreen.Dock = DockStyle.Fill;

            // 4. Add it to the panel to display it!
            pnlContent.Controls.Add(studentsScreen);
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Clear whatever is currently inside the panel
            pnlContent.Controls.Clear();

            // 2. Create your new responsive screen
            Form5 issueBookScreen = new Form5();

            // 3. Tell it to stretch and fill the panel perfectly
            issueBookScreen.Dock = DockStyle.Fill;

            // 4. Add it to the panel to display it!
            pnlContent.Controls.Add(issueBookScreen);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Clear whatever is currently inside the panel
            pnlContent.Controls.Clear();

            // 2. Create your new responsive screen
            Form6 returnBookScreen = new Form6();

            // 3. Tell it to stretch and fill the panel perfectly
            returnBookScreen.Dock = DockStyle.Fill;

            // 4. Add it to the panel to display it!
            pnlContent.Controls.Add(returnBookScreen);
        }

        private void exitSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn form1 = new LogIn();
            form1.ShowDialog();
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // This deals the Home Control widget into the center panel immediately!
            OpenChildForm(new HomeControl());
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            //Dashboard dashboard = new Dashboard();
            //dashboard.ShowDialog();
        }
        // This is the engine that swaps your screens!
        private void OpenChildForm(UserControl childControl)
        {
            // 1. Clear out whatever screen is currently in the panel
            pnlContent.Controls.Clear();

            // 2. Tell the new screen to stretch and fill the whole space
            childControl.Dock = DockStyle.Fill;

            // 3. Add the new screen to the panel
            pnlContent.Controls.Add(childControl);

            // 4. Make sure it sits on top of everything else
            childControl.BringToFront();
        }
    }
}
