using BaseClass.DataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.Services
{
    public static class SettingService
    {
        private static WorkSetting workSetting = new WorkSetting();

        public static Setting GetSetting()
        {
            if (workSetting.GetAll().Count < 1)
                GenerateSetting();
            return workSetting.GetSetting();
        }

        public static void GenerateSetting()
        {
            workSetting.Add(new Setting());
        }

        public static void UpdateSetting(Setting setting)
        {
            workSetting.Update(setting);
        }
    }
}
