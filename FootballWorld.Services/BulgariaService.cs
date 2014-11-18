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
    public class BulgariaService : BaseService
    {
        const int PageSize = 4;
        const int ListArticleContentLength = 150;
        const string CategoryName = "Bulgaria";

        public IEnumerable<ListArticleViewModel> GetArticles(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);

            var viewModels = this.Data.Articles.FindAll().Where(x => x.Category.CategoryName == CategoryName)
                .Skip((pageNumber - 1) * PageSize).Take(PageSize);
            var articles = viewModels.Select(x => Mapper.Map<Article, ListArticleViewModel>(x))
                .Select(x => { x.Content = x.Content.Substring(0, ListArticleContentLength) + "..."; return x; });

            return articles;
        }

        public int GetArticlesCount()
        {
            return this.Data.Articles.FindAll().Where(x => x.Category.CategoryName == CategoryName).Count();
        }
    }
}
