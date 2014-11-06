using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FootballWorld.Data;

namespace FootballWorld.Services
{
    public class BaseService
    {
        protected IFootballWorldData Data;

        public BaseService(IFootballWorldData data)
        {
            this.Data = data;
        }

        public BaseService()
            : this(new FootballWorldData())
        { }
    }
}
