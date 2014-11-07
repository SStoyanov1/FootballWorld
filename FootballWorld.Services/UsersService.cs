using FootballWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorld.Services
{
    public class UsersService : BaseService
    {
        public ApplicationUser GetUserByUserName(string UserName)
        {
            var user = this.Data.Users.FindAll().Where(us => us.UserName == UserName).FirstOrDefault();
            return user;
        }
    }
}
