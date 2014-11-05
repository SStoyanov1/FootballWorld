using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorld.Data
{
    public class EFRepository<M> : IRepository<M> where M : class
    {
        internal virtual DbSet<M> EntitySet
        {
            get
            {
                return DB.Set<M>();
            }
        }

        protected static ApplicationDbContext DB { get; private set; }

        public EFRepository(ApplicationDbContext db)
        {
            DB = db;
        }

        public ICollection<M> FindAll()
        {
            return EntitySet.ToList();
        }

        public IEnumerable<M> FindAllEnumerable()
        {
            return EntitySet.AsEnumerable();
        }

        public M FindById(int id)
        {
            return EntitySet.Find(id);
        }

        public M Add(M instance)
        {
            M result = EntitySet.Add(instance);
            DB.SaveChanges();
            return result;
        }

        public IEnumerable<M> AddRange(IEnumerable<M> entities)
        {
            IEnumerable<M> result = EntitySet.AddRange(entities);
            DB.SaveChanges();
            return result;
        }

        public void AddRangeAsync(IEnumerable<M> entities)
        {
            EntitySet.AddRange(entities);
            int id = DB.SaveChangesAsync().Result;
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public void DeleteById(int id)
        {
            M instance = FindById(id);
            Delete(instance);
        }

        public void Delete(M instance)
        {
            EntitySet.Remove(instance);
            DB.SaveChanges();
        }

        public void DeleteRange(IEnumerable<M> entities)
        {
            EntitySet.RemoveRange(entities);
            DB.SaveChanges();
        }

        public int DeleteRangeAsync(IEnumerable<M> entities)
        {
            EntitySet.RemoveRange(entities);
            return DB.SaveChangesAsync().Result;
        }
    }
}
