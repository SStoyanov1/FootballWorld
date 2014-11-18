using FootballWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Areas.Categories.Controllers
{
    public class OthersController : Controller
    {
        private const int PageSize = 4;

        private OthersService _othersService;

        public OthersController(OthersService othersService)
        {
            _othersService = othersService;
        }

        // GET: Categories/Bulgaria
        public ActionResult Index(int? id)
        {
            var articles = _othersService.GetArticles(id);
            var allArticlesCount = _othersService.GetArticlesCount();
            ViewBag.Pages = Math.Ceiling((double)allArticlesCount / PageSize);
            return View(articles);
        }
    }
}