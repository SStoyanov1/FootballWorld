using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;

using FootballWorld.Data;
using FootballWorld.Model;
using FootballWorld.ViewModel;
using System.Web;

namespace FootballWorld.Services
{
    public class ArticlesService : BaseService
    {
        private IRepository<Article> _articleRepository;

        public ArticlesService(ApplicationDbContext db)
        {
            _articleRepository = new EFRepository<Article>(db);
        }

        public IEnumerable<Article> GetViews()
        {
            IEnumerable<Article> articles = this.Data.Articles.FindAll();
            return articles;
        }

        public int Create(CreateArticleViewModel article)
        {
            byte[] uploadFile = new byte[article.Image.InputStream.Length];
            article.Image.InputStream.Read(uploadFile, 0, uploadFile.Length);

            Article articleToCreate = Mapper.Map<CreateArticleViewModel, Article>(article);
            articleToCreate.Image = uploadFile;

            var articleCreated = this.Data.Articles.Add(articleToCreate);
            return articleCreated.Id;
        }

        public DetailsArticleViewModel GetView(int id)
        {
            var article = this.Data.Articles.FindById(id);
            var articleToShow = Mapper.Map<Article, DetailsArticleViewModel>(article);
            return articleToShow;
        }

        public int Edit(DetailsArticleViewModel article, HttpPostedFileBase image)
        {
            var articleToEdit = this.Data.Articles.FindById(article.Id);

            if (image != null)
            {
                byte[] uploadFile = new byte[image.InputStream.Length];
                image.InputStream.Read(uploadFile, 0, uploadFile.Length);
                article.Image = uploadFile;
            }
            else
            {
                article.Image = articleToEdit.Image;
            }

            Mapper.DynamicMap<DetailsArticleViewModel, Article>(article, articleToEdit);

            this.Data.Articles.Save();
            return articleToEdit.Id;
        }

        public void Delete(DetailsArticleViewModel articleToDelete)
        {
            this.Data.Articles.DeleteById(articleToDelete.Id);
        }
    }
}
