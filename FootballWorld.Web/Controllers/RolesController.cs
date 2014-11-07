using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using FootballWorld.Services;
using FootballWorld.Model;
using FootballWorld.Data;

namespace FootballWorld.Controllers
{
    public class RolesController : Controller
    {
        private RolesService _rolesService;
        private UsersService _usersService;

        public RolesController(RolesService rolesService, UsersService usersService)
        {
            _rolesService = rolesService;
            _usersService = usersService;
        }

        // GET: Roles
        public ActionResult Index()
        {
            var roles = _rolesService.GetAllRoles();
            return View(roles);
        }

        //GET Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            _rolesService.Create(collection);
            ViewBag.ResultMessage = "Role created successfully !";
            return RedirectToAction("Index");

        }

        public ActionResult Delete(string roleName)
        {
            _rolesService.DeleteRoleByName(roleName);
            return RedirectToAction("Index");
        }

        //GET /Roles/Edit/5
        public ActionResult Edit(string roleName)
        {
            var roleToEdit = _rolesService.GetByName(roleName);
            return View(roleToEdit);
        }

        //POST /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            _rolesService.Edit(role);
            return RedirectToAction("Index");
        }

        public ActionResult ManageUserRoles()
        {
            // prepopulat roles for the view dropdown
            var list = _rolesService.GetListOfRoles();
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            var user = _usersService.GetUserByUserName(UserName);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            userManager.AddToRole(user.Id, RoleName);

            ViewBag.ResultMessage = "Role created successfully !";

            var list = _rolesService.GetListOfRoles();
            ViewBag.Roles = list;
            
            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var user = _usersService.GetUserByUserName(UserName);
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var list = _rolesService.GetListOfRoles();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var user = _usersService.GetUserByUserName(UserName);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            if (userManager.IsInRole(user.Id, RoleName))
            {
                userManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            // prepopulat roles for the view dropdown
            var list = _rolesService.GetListOfRoles();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }
    }
}