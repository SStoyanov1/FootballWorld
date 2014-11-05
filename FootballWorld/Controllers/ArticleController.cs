using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FootballWorld.Services;

namespace FootballWorld.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService _articleService;

        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: Articles
        public ActionResult Index()
        {
            var articles = _articleService.GetViews();
            return View(articles);
        }
    }
}