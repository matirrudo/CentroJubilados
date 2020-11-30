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
    public class WorkUser : IWorkGeneric<User>
    {
        public override void Add(User entity)
        {
            em.User.Add(entity);
            em.SaveChanges();
        }

        public override void Delete(int id)
        {
            User user = em.User.Where(u => u.Id == id).First<User>();
            if (user != null)
            {
                em.User.Remove(user);
                em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Usuario no encontrado");
            }
        }

        public override List<User> GetAll()
        {
            return em.User.ToList<User>();
        }

        public override User GetEntity(int id)
        {
            return em.User.Where(u => u.Id == id).First<User>();
        }

        public override void Update(User entity)
        {
            User user = em.User.Find(entity.Id);
            if (user != null)
            {
                user.RolId = entity.RolId;
                user.Password = entity.Password;
                user.Firstname = entity.Firstname;
                user.Lastname = entity.Lastname;
                user.Username = entity.Username;
                em.Entry(user.Rol).State = EntityState.Unchanged;
                em.SaveChanges();
            }
            else
                throw new ArgumentException("Usuario no encontrado");
        }

        public User SearchUserByUsername(string username)
        {
            if (em.User.Where(u => u.Username == username).Count() == 0)
            {
                return null;
            }
            return em.User.Where(u => u.Username == username).First();
        }
    }
}
