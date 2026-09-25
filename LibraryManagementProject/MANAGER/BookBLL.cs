using LibraryManagementProject.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject.BLL
{
    public class BookBLL
    {
        private BookDAL _bookDAL = new BookDAL();
        public string AddNewBook(string title, string isbn, string category, string copiesText)
        {
            if(string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(copiesText))
            {
                return "Titles and Copies are Required";
            }
            int copies;
            if(!int.TryParse(copiesText, out copies))
            {
                return "Copies must be a Valid Number";
            }
            bool success = _bookDAL.AddBook(title, isbn, category, copies);
            if (success)
            {
                return "Success";
            }
            else
            {
                return "Database Error: Could not Add Book";
            }
        }
        // Add this 'using' at the top if you don't have it:
        // using System.Data;

        public DataTable GetAllBooks()
        {
            return _bookDAL.GetAllBooks();
        }

        public string UpdateExistingBook(int bookId, string title, string isbn, string category, string copiesText)
        {
            if (bookId == 0) return "Please select a book from the list first.";
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(copiesText)) return "Title and Copies are required!";

            int copies;
            if (!int.TryParse(copiesText, out copies)) return "Copies must be a valid number.";

            bool success = _bookDAL.UpdateBook(bookId, title, isbn, category, copies);
            return success ? "Success" : "Failed to update book.";
        }

        public string DeleteExistingBook(int bookId)
        {
            if (bookId == 0) return "Please select a book from the list first.";
            return _bookDAL.DeleteBook(bookId);
        }
    }
}
