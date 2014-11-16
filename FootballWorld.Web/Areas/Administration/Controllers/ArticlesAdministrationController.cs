using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FootballWorld.Services;
using FootballWorld.Model;
using FootballWorld.Models;
using FootballWorld.ViewModel;

namespace FootballWorld.Areas.Administration.Controllers
{
    [Authorize(Roles = "Publicist, Moderator, Admin")]
    public class ArticlesAdministrationController : Controller
    {
        private ArticlesService _articleService;
        private UsersService _usersService;
        private CategoriesService _categoriesService;

        public ArticlesAdministrationController(ArticlesService articleService, UsersService usersService, CategoriesService categoriesService)
        {
            _articleService = articleService;
            _usersService = usersService;
            _categoriesService = categoriesService;
        }

        // GET: Administration/Articles
        public ActionResult Index()
        {
            var articles = _articleService.GetViews();
            return View(articles);
        }

        //GET Administration/Articles/Create
        public ActionResult Create()
        {
            var createArtileViewModel = new CreateArticleViewModel();
            createArtileViewModel.Categories = _categoriesService.GetCategories();
            return View(createArtileViewModel);
        }

        //POST Administration/Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateArticleViewModel article) 
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            article.AuthorId = _usersService.GetUserByUserName(this.User.Identity.Name).Id;
            _articleService.Create(article);
            return RedirectToAction("Index");
        }

        //GET Administration/Articles/Edit
        public ActionResult Edit(int id)
        {
            var article = _articleService.GetView(id);
            return View(article);
        }

        //POST Administration/Articles/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetailsArticleViewModel article, HttpPostedFileBase updatedImage)
        {
            var editedArticle = _articleService.Edit(article, updatedImage);
            return RedirectToAction("Details", "Articles", new { Area = "", id = editedArticle });
        }

        //GET Administration/Articles/Delete
        public ActionResult Delete(int id)
        {
            DetailsArticleViewModel article = _articleService.GetView(id);
            return View(article);
        }

        //POST Administration/Articles/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DetailsArticleViewModel article)
        {
            _articleService.Delete(article);
            return RedirectToAction("Index", "Articles", new { Area = "" });
        }
    }
}