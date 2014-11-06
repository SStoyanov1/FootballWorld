using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;

using FootballWorld.Data;
using FootballWorld.Model;
using FootballWorld.ViewModel;

namespace FootballWorld.Services
{
    public class ArticleService
    {
        private IRepository<Article> _articleRepository;

        public ArticleService(ApplicationDbContext db)
        {
            _articleRepository = new EFRepository<Article>(db);
        }

        public IEnumerable<Article> GetViews()
        {
            IEnumerable<Article> articles = _articleRepository.FindAll();
            return articles;
        }

        public int Create(CreateArticleViewModel article)
        {
            Article articleToCreate = new Article();

            byte[] uploadFile = new byte[article.Image.InputStream.Length];
            article.Image.InputStream.Read(uploadFile, 0, uploadFile.Length);

            articleToCreate.Title = article.Title;
            articleToCreate.Content = article.Content;
            articleToCreate.Subtitle = article.Subtitle;
            articleToCreate.ImageName = article.Image.FileName;
            articleToCreate.Image = uploadFile;
            articleToCreate.DateCreated = DateTime.Now;

            var articleCreated = _articleRepository.Add(articleToCreate);
            return articleCreated.Id;
        }

        public DetailsArticleViewModel GetView(int id)
        {
            var article = _articleRepository.FindById(id);

            var articleToShow = new DetailsArticleViewModel();
            articleToShow.Id = article.Id;
            articleToShow.Title = article.Title;
            articleToShow.Subtitle = article.Subtitle;
            articleToShow.Content = article.Content;
            articleToShow.DateCreated = article.DateCreated;
            articleToShow.Image = article.Image;

            return articleToShow;
        }
    }
}
