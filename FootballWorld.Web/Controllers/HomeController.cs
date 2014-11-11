using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FootballWorld.Services;

namespace FootballWorld.Controllers
{
    public class HomeController : Controller
    {
        ArticlesService _articlesService;

        public HomeController(ArticlesService articlesService)
        {
            _articlesService = articlesService;
        }
        
        public ActionResult Index()
        {
            var articles = _articlesService.GetLastFiveViews();
            return View(articles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}