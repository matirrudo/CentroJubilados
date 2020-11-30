using BaseClass.DataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.Services
{
    public static class LoginService
    {
        public static User userLogged;

        public static bool Login(string username, string password)
        {
            WorkUser wu = new WorkUser();
            User user = wu.SearchUserByUsername(username);

            if (user is null)
                return false;
            else
            {
                if (user.Password.Equals(password))
                {
                    userLogged = user;
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
