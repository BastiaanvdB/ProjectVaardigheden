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

    }
}
