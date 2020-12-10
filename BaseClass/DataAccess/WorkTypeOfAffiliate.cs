using BaseClass.IDataAccess;
using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.DataAccess
{
    public class WorkTypeOfAffiliate : IWorkGeneric<TypeOfAffiliate>
    {
        public override void Add(TypeOfAffiliate entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<TypeOfAffiliate> GetAll()
        {
            return em.TypeOfAffiliate.ToList();
        }

        public override TypeOfAffiliate GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(TypeOfAffiliate entity)
        {
            throw new NotImplementedException();
        }
    }
}
