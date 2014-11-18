using FootballWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Areas.Categories.Controllers
{
    public class EnglandController : Controller
    {
        private const int PageSize = 4;

        private EnglandService _englandService;

        public EnglandController(EnglandService englandService)
        {
            _englandService = englandService;
        }

        // GET: Categories/Bulgaria
        public ActionResult Index(int? id)
        {
            var articles = _englandService.GetArticles(id);
            var allArticlesCount = _englandService.GetArticlesCount();
            ViewBag.Pages = Math.Ceiling((double)allArticlesCount / PageSize);
            return View(articles);
        }
    }
}