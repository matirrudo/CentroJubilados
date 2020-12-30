using BaseClass.IDataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.DataAccess
{
    class WorkLog : IWorkGeneric<Log>
    {
        public override void Add(Log entity)
        {
            em.Log.Add(entity);
            em.SaveChanges();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Log> GetAll()
        {
            return em.Log.ToList<Log>();
        }

        public override Log GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
