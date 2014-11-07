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
    public class ArticlesController : Controller
    {
        private ArticlesService _articleService;

        public ArticlesController(ArticlesService articleService)
        {
            _articleService = articleService;
        }

        // GET: Articles
        public ActionResult Index()
        {
            var articles = _articleService.GetViews();
            return View(articles);
        }

        //GET Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateArticleViewModel article) 
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            _articleService.Create(article);
            return RedirectToAction("Index");
        }

        //GET Articles/Details
        public ActionResult Details(int id)
        {
            var article = _articleService.GetView(id);
            return View(article);
        }

        //GET Articles/Edit
        public ActionResult Edit(int id)
        {
            var article = _articleService.GetView(id);
            return View(article);
        }

        //POST Articles/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetailsArticleViewModel article, HttpPostedFileBase updatedImage)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            _articleService.Edit(article, updatedImage);
            return RedirectToAction("Index");
        }

        //GET Articles/Delete
        public ActionResult Delete(int id)
        {
            DetailsArticleViewModel article = _articleService.GetView(id);
            return View(article);
        }

        //POST Articles/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DetailsArticleViewModel article)
        {
            _articleService.Delete(article);
            return RedirectToAction("Index", "Articles");
        }
    }
}