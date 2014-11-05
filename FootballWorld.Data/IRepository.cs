using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorld.Data
{
    public interface IRepository<M>
    {
        ICollection<M> FindAll();
        M FindById(int id);
        M Add(M instance);
        void Save();
        void DeleteById(int id);
        void Delete(M instance);
    }
}
