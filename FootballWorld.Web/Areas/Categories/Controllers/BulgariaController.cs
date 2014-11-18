using FootballWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Areas.Categories.Controllers
{
    public class BulgariaController : Controller
    {
        private const int PageSize = 4;

        private BulgariaService _bulgariaService;

        public BulgariaController(BulgariaService bulgariaService)
        {
            _bulgariaService = bulgariaService;
        }

        // GET: Categories/Bulgaria
        public ActionResult Index(int? id)
        {
            var articles = _bulgariaService.GetArticles(id);
            var allArticlesCount = _bulgariaService.GetArticlesCount();
            ViewBag.Pages = Math.Ceiling((double)allArticlesCount / PageSize);
            return View(articles);
        }
    }
}