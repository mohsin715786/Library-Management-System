using System;
using System.Data;
using System.Windows.Forms;

namespace LibraryManagementProject
{
    public partial class Form6 : UserControl
    {
        private LibraryManagementProject.BLL.ReturnBLL returnManager = new LibraryManagementProject.BLL.ReturnBLL();

        // Variables to hold the selected row's data
        private string selectedIssueId = "";
        private string selectedBookId = "";

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // 1. Apply your specific grid formatting
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // 2. Load all active loans immediately when the window opens
            RefreshGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Fetch loans filtered by the typed Roll No
            dgvBooks.DataSource = returnManager.GetActiveLoans(txtRollNo.Text);
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Grab the IDs when the user clicks a row
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
                selectedIssueId = row.Cells["IssueID"].Value.ToString();
                selectedBookId = row.Cells["BookID"].Value.ToString();
            }
        }

        private void btnConfirmReturn_Click(object sender, EventArgs e)
        {
            // Process the return using the selected IDs
            string result = returnManager.ProcessReturn(selectedIssueId, selectedBookId);

            if (result == "Success")
            {
                MessageBox.Show("Book returned successfully! Inventory updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear selections and refresh the grid
                selectedIssueId = "";
                selectedBookId = "";
                txtRollNo.Clear();
                RefreshGrid();
            }
            else
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshGrid()
        {
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // Load all active loans
            dgvBooks.DataSource = returnManager.GetActiveLoans();
        }
    }
}