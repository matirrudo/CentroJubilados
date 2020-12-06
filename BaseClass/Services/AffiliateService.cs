using BaseClass.DataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.Services
{
    public static class AffiliateService
    {
        //TODO: Agregar Logs en cada metodo
        private static WorkAffiliate workAffiliate = new WorkAffiliate();

        public static void Add(Affiliate affiliate)
        {
            workAffiliate.Add(affiliate);
        }

        public static void Delete(Affiliate affiliate)
        {
            workAffiliate.Delete(affiliate.Id);
        }

        public static List<Affiliate> GetAll()
        {
            return workAffiliate.GetAll();
        }

        public static Affiliate GetAffiliate(int id)
        {
            return workAffiliate.GetEntity(id);
        }

        public static void Update(Affiliate affiliate)
        {
            workAffiliate.Update(affiliate);
        }

    }
}
