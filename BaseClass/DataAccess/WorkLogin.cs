using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.DataAccess
{
    public static class WorkLogin
    {
        public static User user;
        

        public static bool Login(string username, string password)
        {
            WorkUser wu = new WorkUser();
            return true;
        }
    }
}
