using FootballWorld.Services;
using FootballWorld.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballWorld.Areas.Comments.Controllers
{
    public class CommentsController : Controller
    {
        private CommentsService _commentsService;
        private UsersService _usersService;

        public CommentsController(CommentsService commentsService, UsersService usersService)
        {
            this._commentsService = commentsService;
            this._usersService = usersService;
        }

        // GET: Comments/Comments
        public ActionResult Index()
        {
            return View();
        }

        // POST: Comments/Comments/PostComment
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentViewModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var author = _usersService.GetUserByUserName(this.User.Identity.Name);
                commentModel.AuthorId = author.Id;

                _commentsService.AddComment(commentModel);

                var viewModel = new CommentViewModel { AuthorUsername = author.UserName, Content = commentModel.Comment, ProfileImage = author.ProfileImage };
                return PartialView("~/Areas/Comments/Views/Shared/_CommentPartial.cshtml", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
    }
}