using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class User_Service
    {
        User_DAO user_db = new User_DAO();

        public bool UserLoginAuth(string Username, string Password)
        {
            return user_db.Db_Login_Check_User(Username, Password);
        }

        public User Get_User(string Username, string Password)
        {
            return user_db.DB_Get_User(Username, Password);
        }

        public bool LicenseCheck(string License)
        {
            return user_db.DB_License_Check(License);
        }

        public bool UserRegistration(User user)
        {
            return user_db.DB_Register_User(user);
        }
        
        public bool CheckIfExist(string Username)
        {
            return user_db.DB_Check_Already_Registrated(Username);
        }

        public bool CheckAdminStatus(string Username, string Password)
        {
            return user_db.DB_Check_Admin_Status(Username, Password);
        }

        public List<AdminRequest> GetRequests()
        {
            return user_db.DB_Get_Admin_Requests();
        }

        public void RemoveRequest(int RequestId)
        {
            user_db.DB_Remove_Admin_Request(RequestId);
        }

        public void MakeUserAdmin(string Username)
        {
            user_db.DB_Make_User_Admin(Username);
        }

        public bool CreateAdminRequest(string Username)
        {
            return user_db.DB_Make_Admin_Request(Username);
        }
        public String FetchSecurityQuestion(string Username)
        {
            return user_db.DB_Fetch_Security_Question(Username);
        }
        public User FetchSecurityAnswer(string Username,string answer)
        {
            return user_db.DB_Fetch_Security_Answer(Username, answer);
        }
        public void UpatePasswordOnly(string Username, string answer, string password)
        {
            user_db.DB_Update_Password_Only(Username, answer, password);
        }
        public void UpdateSecurity(string Username,  string secQ, string secA, string password)
        {
            user_db.DB_Update_Security(Username, secQ, secA, password);
        }
    }
}
