using BaseClass.IDataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.DataAccess
{
    class WorkSetting : IWorkGeneric<Setting>
    {
        public override void Add(Setting entity)
        {
            em.Setting.Add(entity);
            em.SaveChanges();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Setting> GetAll()
        {
            return em.Setting.ToList();
        }

        public override Setting GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Setting entity)
        {
            Setting setting = em.Setting.Where(m => m.Id == entity.Id).First<Setting>();
            if (setting != null)
            {
                setting.UserId = entity.UserId;
                setting.ContributionPrice = entity.ContributionPrice;
                setting.MonthContribution = entity.MonthContribution;
                setting.YearContribution = entity.YearContribution;
                em.SaveChanges();
            }
            else
                throw new ArgumentException("Configuracion no encontrada");
        }

        public Setting GetSetting()
        {
            return em.Setting.First();
        }
    }
}
