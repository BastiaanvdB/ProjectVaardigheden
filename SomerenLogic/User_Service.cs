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

    }
}
