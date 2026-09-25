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
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {
            try
            {
                // Example: Call your BookManager to get the total count
                LibraryManagementProject.BLL.BookBLL bookManager = new LibraryManagementProject.BLL.BookBLL();

                // Let's pretend your BookManager has a method to count books
                int totalBooks = bookManager.GetAllBooks().Rows.Count;

                // Update the label on the screen!
                lblTotalBooks.Text = totalBooks.ToString();
            }
            catch (Exception)
            {
                // Just in case something goes wrong
                lblTotalBooks.Text = "0";
            }
        }
    }
}
