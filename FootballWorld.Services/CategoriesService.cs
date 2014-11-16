using FootballWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorld.Services
{
    public class CategoriesService : BaseService
    {
        public IEnumerable<Category> GetCategories()
        {
            return this.Data.Categories.FindAll();
        }
    }
}
