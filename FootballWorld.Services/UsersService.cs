using FootballWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using FootballWorld.ViewModel;
using System.Web;

namespace FootballWorld.Services
{
    public class UsersService : BaseService
    {
        private const int PageSize = 4;

        public IEnumerable<UsersListViewModel> GetUsersViews(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);
            
            var users = this.Data.Users.FindAll().Select(us => Mapper.Map<ApplicationUser, UsersListViewModel>(us))
                .Skip((pageNumber - 1) * PageSize).Take(PageSize); ;

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

        public string Edit(UsersListViewModel user, HttpPostedFileBase image)
        {
            var userToEdit = this.Data.Users.FindAll().Where(us => us.Id == user.Id).FirstOrDefault();
            if (user.UserName == null)
            {
                user.UserName = userToEdit.UserName;
            }
            if (image != null)
            {
                byte[] uploadFile = new byte[image.InputStream.Length];
                image.InputStream.Read(uploadFile, 0, uploadFile.Length);
                user.ProfileImage = uploadFile;
            }
            else
            {
                user.ProfileImage = userToEdit.ProfileImage;
            }
            Mapper.DynamicMap<UsersListViewModel, ApplicationUser>(user, userToEdit);
            this.Data.Users.Save();
            return userToEdit.Id;
        }

        public object GetUserCount()
        {
            return this.Data.Users.FindAll().Count();
        }
    }
}
