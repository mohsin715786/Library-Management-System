using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementProject.DAL
{
    public class ReturnDAL
    {
        // Replace with your actual server name!
        private string connectionString = "Data Source=mohsin\\sqlexpress;Initial Catalog=CampusLibraryDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // Fetches all active loans, or filters by Roll No if provided
        public DataTable GetActiveLoans(string rollNo = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT IssueID, BookID, StudentRollNo, IssueDate FROM IssuedBooks WHERE Status = 'Issued'";

                if (!string.IsNullOrWhiteSpace(rollNo))
                {
                    query += " AND StudentRollNo = @RollNo";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(rollNo))
                    {
                        cmd.Parameters.AddWithValue("@RollNo", rollNo);
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Updates the issue status AND adds the book back to inventory
        public bool ProcessReturn(int issueId, int bookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    BEGIN TRAN;
                    UPDATE IssuedBooks SET Status = 'Returned' WHERE IssueID = @IssueID;
                    UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE BookID = @BookID;
                    COMMIT TRAN;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IssueID", issueId);
                    cmd.Parameters.AddWithValue("@BookID", bookId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}