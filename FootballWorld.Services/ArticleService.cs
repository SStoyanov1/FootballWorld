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
            byte[] uploadFile = new byte[article.Image.InputStream.Length];
            article.Image.InputStream.Read(uploadFile, 0, uploadFile.Length);

            Article articleToCreate = Mapper.Map<CreateArticleViewModel, Article>(article);
            articleToCreate.Image = uploadFile;

            var articleCreated = _articleRepository.Add(articleToCreate);
            return articleCreated.Id;
        }

        public DetailsArticleViewModel GetView(int id)
        {
            var article = _articleRepository.FindById(id);
            var articleToShow = Mapper.Map<Article, DetailsArticleViewModel>(article);
            return articleToShow;
        }
    }
}
