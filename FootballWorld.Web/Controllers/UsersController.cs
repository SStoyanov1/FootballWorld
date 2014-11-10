using FootballWorld.Services;
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
    }
}