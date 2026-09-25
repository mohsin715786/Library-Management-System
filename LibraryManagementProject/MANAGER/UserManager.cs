using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementProject.DAL;

namespace LibraryManagementProject.BLL
{
    internal class UserManager
    {
        private UserDAL _userDAL = new UserDAL();

        public string Login(string username, string password)
        {
            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return "Please enter both Username and Password.";
            }
            bool isSuccess = _userDAL.VerifyLogin(username, password);

            if (isSuccess)
            {
                return "Success";
            }
            else
            {
                return "Invalid Username or Password.";
            }
        }
    }
}
