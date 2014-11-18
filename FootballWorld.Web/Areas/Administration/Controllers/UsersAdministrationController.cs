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
        private const int PageSize = 4;

        UsersService _usersService;

        public UsersAdministrationController(UsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: Administration/Users
        public ActionResult Index(string Sorting_Order, int? id)
        {
            var usersViews = _usersService.GetUsersViews(id);
            var allUserViewsCount = _usersService.GetUserCount();
            ViewBag.Pages = Math.Ceiling(Convert.ToDouble(allUserViewsCount) / PageSize);
            return View(usersViews);
        }
    }
}