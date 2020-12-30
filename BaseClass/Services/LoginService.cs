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
        //TODO: Agregar Logs en cada accion
        public static User userLogged;
        private static WorkUser wu = new WorkUser();

        public static bool Login(string username, string password, bool remember)
        {
            User user = wu.SearchUserByUsername(username);
            if (user is null)
                return false;
            else
            {
                if (user.Password.Equals(password))
                {
                    userLogged = user;
                    LogService.AddLog("Entrada al sistema", "Inicio session y entrada al sistema de " + user.Lastname + " " + user.Firstname);
                    if (remember)
                        RememberUser(user);
                    return true;
                }
                else
                    return false;
            }
        }

        private static void RememberUser(User user)
        {
            Setting setting = SettingService.GetSetting();
            setting.UserId = user.Id;
            SettingService.UpdateSetting(setting);
        }

        public static void Logout()
        {
            userLogged = null;
            Setting setting = SettingService.GetSetting();
            setting.UserId = null;
            SettingService.UpdateSetting(setting);
        }

    }
}
