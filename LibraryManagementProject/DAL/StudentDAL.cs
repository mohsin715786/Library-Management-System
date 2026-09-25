using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementProject.DAL
{
    public class StudentDAL
    {
        // Replace YOUR_SERVER with your actual SQL Server name!
        private string connectionString = "Data Source=mohsin\\sqlexpress;Initial Catalog=CampusLibraryDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Grabs everything from the Students table
                string query = "SELECT * FROM Students";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        // Fills the DataTable with the SQL results
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public bool AddStudent(string name, string rollNo, string department, string phone)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Added Department and Phone to the query!
                string query = "INSERT INTO Students (FullName, RollNumber, Department, Phone) VALUES (@Name, @RollNo, @Dept, @Phone)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@RollNo", rollNo);
                    cmd.Parameters.AddWithValue("@Dept", department);
                    cmd.Parameters.AddWithValue("@Phone", phone); // Added phone parameter
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateStudent(int id, string name, string rollNo, string department, string phone)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Added Department and Phone to the update query!
                string query = "UPDATE Students SET FullName=@Name, RollNumber=@RollNo, Department=@Dept, Phone=@Phone WHERE StudentID=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@RollNo", rollNo);
                    cmd.Parameters.AddWithValue("@Dept", department);
                    cmd.Parameters.AddWithValue("@Phone", phone); // Added phone parameter
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Students WHERE StudentID=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // This will pop up the EXACT reason SQL rejected it!
                System.Windows.Forms.MessageBox.Show("SQL ERROR: " + ex.Message);
                return false;
            }
        }
    }
}