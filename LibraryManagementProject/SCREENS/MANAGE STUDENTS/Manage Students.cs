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
    public partial class Form4 : UserControl
    {
        private string selectedStudentId = "";
        private LibraryManagementProject.BLL.StudentBLL studentManager = new LibraryManagementProject.BLL.StudentBLL();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // 2. Attach the data to the grid! (Make sure your grid is actually named dataGridView1)
            dataGridView1.DataSource = studentManager.GetAllStudents();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Notice we added txtPhone.Text at the end!
            string result = studentManager.AddStudent(txtFullName.Text, txtRollNo.Text, txtDepartment.Text, txtPhone.Text);
            if (result == "Success")
            {
                MessageBox.Show("Student Added!");
                RefreshGrid();
            }
            else MessageBox.Show(result);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Added txtPhone.Text here too!
            string result = studentManager.UpdateStudent(selectedStudentId, txtFullName.Text, txtRollNo.Text, txtDepartment.Text, txtPhone.Text);
            if (result == "Success")
            {
                MessageBox.Show("Student Updated!");
                RefreshGrid();
            }
            else MessageBox.Show(result);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string result = studentManager.DeleteStudent(selectedStudentId);
            if (result == "Success")
            {
                MessageBox.Show("Student Deleted!");
                RefreshGrid();
                selectedStudentId = ""; // Clear selection
            }
            else
            {
                MessageBox.Show(result);
            }
        }
        // --- GRID CLICK LOGIC ---
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // We fixed the column names to perfectly match your database screenshot!
                selectedStudentId = row.Cells["StudentID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtRollNo.Text = row.Cells["RollNumber"].Value.ToString();
                txtDepartment.Text = row.Cells["Department"].Value.ToString();

                // Added the Phone line so clicking the grid fills the phone box
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
            }
        }

        // A helper method to reload the grid after making changes
        private void RefreshGrid()
        {
            dataGridView1.DataSource = studentManager.GetAllStudents();
            txtDepartment.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtRollNo.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
