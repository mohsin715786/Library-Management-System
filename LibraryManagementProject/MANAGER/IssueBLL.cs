using System;
using LibraryManagementProject.DAL;

namespace LibraryManagementProject.BLL
{
    public class IssueBLL
    {
        private IssueDAL _issueDAL = new IssueDAL();

        public string IssueBook(string bookIdText, string studentRollNo)
        {
            // 1. Check for empty fields
            if (string.IsNullOrWhiteSpace(bookIdText) || string.IsNullOrWhiteSpace(studentRollNo))
            {
                return "Please enter both Book ID and Student Roll No.";
            }

            // 2. Make sure Book ID is a valid number
            int bookId;
            if (!int.TryParse(bookIdText, out bookId))
            {
                return "Book ID must be a valid number.";
            }

            // 3. Send to DAL
            bool success = _issueDAL.IssueBookToStudent(bookId, studentRollNo);

            if (success)
            {
                return "Success";
            }
            else
            {
                return "Failed to issue book. Check if Book ID exists and copies are available.";
            }
        }
    }
}