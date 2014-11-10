using FootballWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using FootballWorld.ViewModel;

namespace FootballWorld.Services
{
    public class UsersService : BaseService
    {
        public IEnumerable<UsersListViewModel> GetAllUsersViews()
        {
            var users = this.Data.Users.FindAll().Select(us => Mapper.Map<ApplicationUser, UsersListViewModel>(us));
            return users;
        }

        public ApplicationUser GetUserByUserName(string UserName)
        {
            var user = this.Data.Users.FindAll().Where(us => us.UserName == UserName).FirstOrDefault();
            return user;
        }

        public UsersListViewModel GetView(string id)
        {
            var user = this.Data.Users.FindAll().AsQueryable().Where(us => us.Id == id).
                Select(us => Mapper.Map<ApplicationUser, UsersListViewModel>(us)).FirstOrDefault();
            return user;
        }
    }
}
