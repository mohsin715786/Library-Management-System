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
    public partial class Manage_Books_UI : UserControl
    {
        // SECRET VARIABLE: This remembers which book is selected in the grid
        private int selectedBookID = 0;
        LibraryManagementProject.BLL.BookBLL bookBLL = new LibraryManagementProject.BLL.BookBLL();
        public Manage_Books_UI()
        {
            InitializeComponent();
        }
        private void btnADD_Click(object sender, EventArgs e)
        {

            string result = bookBLL.AddNewBook(txtTitle.Text, txtISBN.Text, cmbCategory.Text, txtCopies.Text);

            if (result == "Success")
            {
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTitle.Clear();
                txtISBN.Clear();
                txtCopies.Clear();
                cmbCategory.SelectedIndex = -1;

                LoadGrid();
            }
            else
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            // ADD THIS LINE: Tells the columns to stretch and fill the empty space
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            // Assuming your grid is named dgvBooks
            dgvBooks.DataSource = bookBLL.GetAllBooks();
            // Clear text boxes and reset ID
            txtTitle.Clear();
            txtISBN.Clear();
            txtCopies.Clear();
            cmbCategory.SelectedIndex = -1;
            selectedBookID = 0;
        }

        // 2. Cell Click Event: Go to your grid properties -> Events (lightning bolt) -> double click CellClick
        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure they clicked a valid row, not the header
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                // Grab the hidden BookID
                selectedBookID = Convert.ToInt32(row.Cells["BookID"].Value);

                // Fill the text boxes with the data from the grid
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                cmbCategory.Text = row.Cells["Category"].Value.ToString();
                txtCopies.Text = row.Cells["TotalCopies"].Value.ToString();
            }
        }

        // 3. Update Button Event: Double-click btnUpdate
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string result = bookBLL.UpdateExistingBook(selectedBookID, txtTitle.Text, txtISBN.Text, cmbCategory.Text, txtCopies.Text);

            if (result == "Success")
            {
                MessageBox.Show("Book updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid(); // Refresh the grid to show changes
            }
            else
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 4. Delete Button Event: Double-click btnDelete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookID == 0)
            {
                MessageBox.Show("Please select a book from the list first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for confirmation before deleting
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string result = bookBLL.DeleteExistingBook(selectedBookID);
                if (result == "Success")
                {
                    MessageBox.Show("Book deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid(); // Refresh the grid
                }
                else
                {
                    MessageBox.Show(result, "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBooks_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Rule 1: Make sure they clicked an actual row, not the header at the top
            if (e.RowIndex >= 0)
            {
                // Rule 2: Get the exact row they clicked on
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                // Rule 3: Save the hidden BookID so the Update/Delete buttons know which book to target
                selectedBookID = Convert.ToInt32(row.Cells["BookID"].Value);

                // Rule 4: Fill the text boxes with the data from that row
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();

                // If you are using a ComboBox for Category, use .Text
                cmbCategory.Text = row.Cells["Category"].Value.ToString();

                txtCopies.Text = row.Cells["TotalCopies"].Value.ToString();
            }
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed was the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // This stops Windows from making that annoying "Ding!" error sound
                e.SuppressKeyPress = true;

                // Move the blinking cursor to the next text box
                txtISBN.Focus();
            }
        }

        private void txtISBN_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed was the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // This stops Windows from making that annoying "Ding!" error sound
                e.SuppressKeyPress = true;

                // Move the blinking cursor to the next text box
                cmbCategory.Focus();
            }
        }

        private void cmbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed was the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // This stops Windows from making that annoying "Ding!" error sound
                e.SuppressKeyPress = true;

                // Move the blinking cursor to the next text box
                txtCopies.Focus();
            }
        }

        private void txtCopies_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed was the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // This stops Windows from making that annoying "Ding!" error sound
                e.SuppressKeyPress = true;

                // Move the blinking cursor to the next button
                btnADD.Focus();
            }
        }

        private void btnADD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // This stops Windows from making that annoying "Ding!" error sound
                e.SuppressKeyPress = true;

                // Move the blinking cursor to the next button
                btnUPDATE.Focus();
            }
        }

        private void btnUPDATE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // This stops Windows from making that annoying "Ding!" error sound
                e.SuppressKeyPress = true;

                // Move the blinking cursor to the next button
                btnDELETE.Focus();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Manage_Books_UI_Load(object sender, EventArgs e)
        {
            // This tells the grid to fetch the data the exact second the screen appears!
            LoadGrid();
        }
    }
}