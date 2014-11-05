using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;

using FootballWorld.Data;
using FootballWorld.Model;

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
    }
}
