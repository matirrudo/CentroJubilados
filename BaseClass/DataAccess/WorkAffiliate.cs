using BaseClass.IDataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.DataAccess
{
    public class WorkAffiliate : IWorkGeneric<Affiliate>
    {
        public override void Add(Affiliate entity)
        {
            em.Affiliate.Add(entity);
            em.SaveChanges();
        }

        public override void Delete(int id)
        {
            Affiliate affiliate = em.Affiliate.Where(a => a.Id == id).First<Affiliate>();
            if (affiliate != null)
            {
                em.Affiliate.Remove(affiliate);
                em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Afiliado no encontrado");
            }
        }

        public override List<Affiliate> GetAll()
        {
            return em.Affiliate.ToList<Affiliate>();
        }

        public override Affiliate GetEntity(int id)
        {
            return em.Affiliate.Where(a => a.Id == id).First<Affiliate>();
        }

        public override void Update(Affiliate entity)
        {
            Affiliate affiliate = em.Affiliate.Find(entity.Id);
            if (affiliate != null)
            {
                affiliate.Lastname = entity.Lastname;
                affiliate.Firstaname = entity.Firstaname;
                affiliate.DNI = entity.DNI;
                affiliate.BenefitNumber = entity.BenefitNumber;
                affiliate.Birthdate = entity.Birthdate;
                affiliate.Address = entity.Address;
                affiliate.RegistrationDate = entity.RegistrationDate;
                affiliate.DateOfReincorporation = entity.DateOfReincorporation;
                affiliate.Active = entity.Active;
                affiliate.TypeOfAffiliateId = entity.TypeOfAffiliateId;
                affiliate.WorkshopId = entity.WorkshopId;

                em.SaveChanges();
            }
            else
                throw new ArgumentException("Afiliado no encontrado");
        }
    }
}
