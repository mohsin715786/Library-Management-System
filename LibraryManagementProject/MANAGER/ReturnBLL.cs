using System.Data;
using LibraryManagementProject.DAL;

namespace LibraryManagementProject.BLL
{
    public class ReturnBLL
    {
        private ReturnDAL _returnDAL = new ReturnDAL();

        public DataTable GetActiveLoans(string rollNo = "")
        {
            return _returnDAL.GetActiveLoans(rollNo);
        }

        public string ProcessReturn(string issueIdText, string bookIdText)
        {
            if (!int.TryParse(issueIdText, out int issueId) || !int.TryParse(bookIdText, out int bookId))
            {
                return "Please select a valid record from the grid first.";
            }

            bool success = _returnDAL.ProcessReturn(issueId, bookId);
            return success ? "Success" : "Failed to process return. Please try again.";
        }
    }
}