using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FootballWorld.Services;
using FootballWorld.Model;
using FootballWorld.Models;
using FootballWorld.ViewModel;

namespace FootballWorld.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService _articleService;

        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: Article
        public ActionResult Index()
        {
            var articles = _articleService.GetViews();
            return View(articles);
        }

        //GET Article/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST Article/Create
        [HttpPost]
        public ActionResult Create(CreateArticleViewModel article) 
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            _articleService.Create(article);
            return View();
        }

        //GET Articles/Details
        public ActionResult Details(int id)
        {
            var article = _articleService.GetView(id);
            return View(article);
        }
    }
}