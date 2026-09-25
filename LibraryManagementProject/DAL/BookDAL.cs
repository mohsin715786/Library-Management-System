using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject.DAL
{
    public class BookDAL
    {
        private string connectionString = "Data Source=mohsin\\sqlexpress;Initial Catalog=CampusLibraryDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public bool AddBook(string title, string isbn, string category, int copies)
        {
            bool isSuccess = false;
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Books (Title, ISBN, Category, TotalCopies, AvailableCopies) " +
                               "VALUES (@title, @isbn, @category, @copies, @copies)";
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@copies", copies);

                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        isSuccess = true;
                    }
                }
            }
            return isSuccess;
        }
        // 1. Get all books to show in the Grid
        public System.Data.DataTable GetAllBooks()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT BookID, Title, ISBN, Category, TotalCopies, AvailableCopies FROM Books";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        // 2. Update an existing book
        public bool UpdateBook(int bookId, string title, string isbn, string category, int copies)
        {
            bool isSuccess = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Note: For simplicity in this uni project, we are only updating TotalCopies.
                // Complex sync with AvailableCopies is skipped to prevent bugs during presentation.
                string query = "UPDATE Books SET Title=@title, ISBN=@isbn, Category=@category, TotalCopies=@copies WHERE BookID=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@copies", copies);
                    cmd.Parameters.AddWithValue("@id", bookId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0) isSuccess = true;
                }
            }
            return isSuccess;
        }

        // 3. Delete a book
        public string DeleteBook(int bookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM Books WHERE BookID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", bookId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return "Success";
                    }
                }
                catch (SqlException ex)
                {
                    // IMPORTANT: If a student has borrowed this book, SQL Server will block the deletion 
                    // because of the Foreign Key in BorrowingRecords. This prevents database corruption!
                    if (ex.Number == 547)
                    {
                        return "Cannot delete this book because it has borrowing history.";
                    }
                    return "Database Error: " + ex.Message;
                }
            }
        }
    }
}
