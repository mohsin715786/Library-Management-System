using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject.DAL
{
    internal class UserDAL
    {
        string ConnectionString = "Data Source=mohsin\\sqlexpress;Initial Catalog=CampusLibraryDB;Integrated Security=True;TrustServerCertificate=True";
        public bool VerifyLogin(string username, string password)
        {
            bool isValid = false;
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                string Query = "SELECT COUNT(1) FROM Users WHERE Username = @user AND Password = @pass";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue ("@pass", password);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if(count == 1)
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }
    }
}
