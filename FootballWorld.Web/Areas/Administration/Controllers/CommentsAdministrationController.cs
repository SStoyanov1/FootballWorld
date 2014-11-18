using FootballWorld.Services;
using FootballWorld.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin, Moderator")] 
    public class CommentsAdministrationController : Controller
    {
        CommentsService _commentsService;

        public CommentsAdministrationController(CommentsService commentsService)
        {
            this._commentsService = commentsService;
        }

        // GET: Administration/CommentsAdministration
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadComments( CommentViewModel request)
        {
            var result = this._commentsService.GetAll()
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    AuthorUsername = x.Author.UserName
                });

            return Json(request, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateComment(CommentViewModel comment)
        {
            comment.Content = this._commentsService.GetAll().Where(x => x.Id == comment.Id).FirstOrDefault().Content;

            return Json(comment, JsonRequestBehavior.AllowGet);
        }
    }
}