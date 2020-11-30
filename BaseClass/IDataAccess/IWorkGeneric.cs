using BaseClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.IDataAccess
{
    public abstract class IWorkGeneric<T> where T : class
    {
        protected CentroJubiladoDbContext em = new CentroJubiladoDbContext();
        public abstract void Add(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(int id);
        public abstract List<T> GetAll();
        public abstract T GetEntity(int id);
    }
}
