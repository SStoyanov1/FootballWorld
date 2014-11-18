using FootballWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Areas.Categories.Controllers
{
    public class GermanyController : Controller
    {
        private const int PageSize = 4;

        private GermanyService _germanyService;

        public GermanyController(GermanyService germanyService)
        {
            _germanyService = germanyService;
        }

        // GET: Categories/Germany
        public ActionResult Index(int? id)
        {
            var articles = _germanyService.GetArticles(id);
            var allArticlesCount = _germanyService.GetArticlesCount();
            ViewBag.Pages = Math.Ceiling((double)allArticlesCount / PageSize);
            return View(articles);
        }
    }
}