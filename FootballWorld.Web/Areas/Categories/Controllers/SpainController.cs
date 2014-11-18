using FootballWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Areas.Categories.Controllers
{
    public class SpainController : Controller
    {
        private const int PageSize = 4;

        private SpainService _spainService;

        public SpainController(SpainService spainService)
        {
            _spainService = spainService;
        }

        public ActionResult Index(int? id)
        {
            var articles = _spainService.GetArticles(id);
            var allArticlesCount = _spainService.GetArticlesCount();
            ViewBag.Pages = Math.Ceiling((double)allArticlesCount / PageSize);
            return View(articles);
        }
    }
}