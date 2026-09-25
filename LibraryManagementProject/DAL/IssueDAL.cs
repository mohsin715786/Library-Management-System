using System;
using System.Data.SqlClient;

namespace LibraryManagementProject.DAL
{
    public class IssueDAL
    {
        // Replace with your actual connection string!
        private string connectionString = "Data Source=mohsin\\sqlexpress;Initial Catalog=CampusLibraryDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public bool IssueBookToStudent(int bookId, string studentRollNo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // First, check if the book actually has available copies!
                string checkQuery = "SELECT AvailableCopies FROM Books WHERE BookID = @BookID";

                // Then, Insert the record AND subtract 1 from AvailableCopies
                string issueQuery = @"
                    BEGIN TRAN;
                    INSERT INTO IssuedBooks (BookID, StudentRollNo, IssueDate, Status) 
                    VALUES (@BookID, @StudentRollNo, GETDATE(), 'Issued');
                    
                    UPDATE Books SET AvailableCopies = AvailableCopies - 1 
                    WHERE BookID = @BookID;
                    COMMIT TRAN;";

                try
                {
                    conn.Open();

                    // 1. Check Copies
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@BookID", bookId);
                        object result = checkCmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) <= 0)
                        {
                            return false; // Book doesn't exist or no copies left
                        }
                    }

                    // 2. Issue the Book
                    using (SqlCommand issueCmd = new SqlCommand(issueQuery, conn))
                    {
                        issueCmd.Parameters.AddWithValue("@BookID", bookId);
                        issueCmd.Parameters.AddWithValue("@StudentRollNo", studentRollNo);

                        int rowsAffected = issueCmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("DATABASE ERROR: " + ex.Message);
                    return false;
                }
            }
        }
    }
}