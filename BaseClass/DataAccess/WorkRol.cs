using BaseClass.IDataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.DataAccess
{
    class WorkRol : IWorkGeneric<Rol>
    {
        public override void Add(Rol entity)
        {
            em.Rol.Add(entity);
            em.SaveChanges();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Rol> GetAll()
        {
            return em.Rol.ToList<Rol>();
        }

        public override Rol GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Rol entity)
        {
            Rol rol = em.Rol.Where(m => m.Id == entity.Id).First<Rol>();
            if (rol != null)
            {
                em.Entry(rol).CurrentValues.SetValues(entity);
                em.SaveChanges();
            }
            else
                throw new ArgumentException("Rol no encontrado");
        }
    }
}
