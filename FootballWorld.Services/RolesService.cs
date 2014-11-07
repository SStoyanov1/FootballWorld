using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FootballWorld.Services
{
    public class RolesService : BaseService
    {
        public void Create(FormCollection collection)
        {
            this.Data.Roles.Add(new IdentityRole()
            {
                Name = collection["RoleName"]
            });
            this.Data.SaveChanges();
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            var roles = this.Data.Roles.FindAll();
            return roles;
        }

        public void DeleteRoleByName(string roleName)
        {
            var roleToDelete = GetByName(roleName);
            this.Data.Roles.Delete(roleToDelete);
            this.Data.SaveChanges();
        }

        public IdentityRole GetByName(string roleName)
        {
            var role = this.Data.Roles.FindAll().Where(x => x.Name == roleName).FirstOrDefault();
            return role;
        }

        public void Edit(IdentityRole role)
        {
            var roleToEdit = this.Data.Roles.FindAll().Where(x => x.Id == role.Id).FirstOrDefault();
            roleToEdit.Name = role.Name;
            this.Data.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetListOfRoles()
        {
            var list = this.Data.Roles.FindAll().OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();

            return list;
        }
    }
}
