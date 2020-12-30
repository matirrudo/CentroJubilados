using BaseClass.DataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.Services
{
    public static class LogService
    {
        private static WorkLog workLog = new WorkLog();
        private static List<Log> logs = new List<Log>();

        /// <summary>
        /// Crea un Log y lo añade a la base de datos.
        /// </summary>
        /// <param name="title">Titulo de Log</param>
        /// <param name="description">Descripcion del Log</param>
        /// <param name="user">Usuario de quien realiza el Log</param>
        public static void AddLog(string title, string description, User user)
        {
            Log log = new Log
            {
                Title = title,
                Description = description,
                UserId = user.Id,
                DateLog = DateTime.Now
            };
            workLog.Add(log);
        }

        /// <summary>
        /// Crea un Log y lo añade a la base de datos.
        /// </summary>
        /// <param name="title">Titulo de Log</param>
        /// <param name="description">Descripcion del Log</param>
        public static void AddLog(string title, string description)
        {
            Log log = new Log
            {
                Title = title,
                Description = description,
                UserId = LoginService.userLogged.Id,
                DateLog = DateTime.Now
            };
            workLog.Add(log);
        }

        public static List<Log> GetLogs()
        {
            logs = workLog.GetAll();
            return logs;
        }

        public static List<Log> GetLogsByUser()
        {
            return logs;
        }
        public static List<Log> GetLogsByDay()
        {
            return logs;
        }
        public static List<Log> GetLogsByWeek()
        {
            return logs;
        }
        public static List<Log> GetLogsByMonth()
        {
            return logs;
        }
        public static List<Log> GetLogsByYear()
        {
            return logs;
        }

    }
}
