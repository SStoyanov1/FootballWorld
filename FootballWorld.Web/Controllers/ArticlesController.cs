using FootballWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticlesService _articleService;
        private UsersService _usersService;

        public ArticlesController(ArticlesService articleService, UsersService usersService)
        {
            _articleService = articleService;
            _usersService = usersService;
        }

        // GET: Articles
        public ActionResult Index()
        {
            return View();
        } 

        //GET Articles/Details/5
        public ActionResult Details(int id)
        {
            var article = _articleService.GetView(id);
            return View(article);
        }
    }
}