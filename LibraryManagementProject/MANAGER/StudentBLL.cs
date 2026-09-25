using System.Data;
using LibraryManagementProject.DAL;

namespace LibraryManagementProject.BLL
{
    public class StudentBLL
    {
        private StudentDAL _studentDAL = new StudentDAL();

        public DataTable GetAllStudents()
        {
            // Just passes the data from the DAL up to the UI
            return _studentDAL.GetAllStudents();
        }
        // Added 'string phone' to the inputs
        public string AddStudent(string name, string rollNo, string department, string phone)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(rollNo))
                return "Student Name and Roll No are required.";

            // Pass the phone to the DAL
            bool success = _studentDAL.AddStudent(name, rollNo, department, phone);
            return success ? "Success" : "Failed to add student to database.";
        }

        // Added 'string phone' here too
        public string UpdateStudent(string idText, string name, string rollNo, string department, string phone)
        {
            if (!int.TryParse(idText, out int id)) return "Please select a valid student to update.";

            bool success = _studentDAL.UpdateStudent(id, name, rollNo, department, phone);
            return success ? "Success" : "Failed to update student.";
        }

        public string DeleteStudent(string idText)
        {
            if (!int.TryParse(idText, out int id)) return "Please select a valid student to delete.";

            bool success = _studentDAL.DeleteStudent(id);
            return success ? "Success" : "Failed to delete student.";
        }
    }
}