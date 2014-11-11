using FootballWorld.Services;
using FootballWorld.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Controllers
{
    public class UsersController : Controller
    {
        UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        //GET Users/Details/5
        public ActionResult Details(string id)
        {
            var user = _usersService.GetView(id);
            return View(user);
        }

        public ActionResult Edit(string id)
        {
            var user = _usersService.GetView(id);
            if (user.UserName != this.HttpContext.User.Identity.Name && !this.HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home", null);
            }
            return View(user);
        }

        //POST Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersListViewModel user, HttpPostedFileBase updatedProfileImage)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var editedUser = _usersService.Edit(user, updatedProfileImage);
            return RedirectToAction("Details", new { id = editedUser });
        }
    }
}