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
    public partial class Form5 : UserControl
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            // Create the BLL object
            LibraryManagementProject.BLL.IssueBLL issueManager = new LibraryManagementProject.BLL.IssueBLL();

            // Call the method and get the message
            string result = issueManager.IssueBook(txtBookID.Text, txtStudentRollNo.Text);

            // Show the result to the user
            if (result == "Success")
            {
                MessageBox.Show("Book successfully issued to student!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the boxes for the next person
                txtBookID.Clear();
                txtStudentRollNo.Clear();
            }
            else
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
