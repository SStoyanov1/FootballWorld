using AutoMapper;
using FootballWorld.Model;
using FootballWorld.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorld.Services
{
    public class CommentsService : BaseService
    {
        public void AddComment(SubmitCommentViewModel comment)
        {
            var commentToAdd = Mapper.Map<SubmitCommentViewModel, Comment>(comment);
            commentToAdd.DateCreated = DateTime.Now;
            this.Data.Comments.Add(commentToAdd);
            this.Data.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return this.Data.Comments.FindAll();
        }
    }
}
