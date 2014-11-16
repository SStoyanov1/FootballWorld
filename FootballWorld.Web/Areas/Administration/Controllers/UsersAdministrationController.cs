using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FootballWorld.Services;

namespace FootballWorld.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersAdministrationController : Controller
    {
        UsersService _usersService;

        public UsersAdministrationController(UsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: Administration/Users
        public ActionResult Index()
        {
            var usersViews = _usersService.GetAllUsersViews();
            return View(usersViews);
        }
    }
}