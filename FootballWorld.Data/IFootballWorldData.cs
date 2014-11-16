namespace FootballWorld.Data
{
    using FootballWorld.Model;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IFootballWorldData
    {
        IRepository<Article> Articles
        {
            get;
        }

        IRepository<Comment> Comments
        {
            get;
        }

        IRepository<IdentityRole> Roles
        {
            get;
        }

        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Category> Categories
        {
            get;
        }

        void SaveChanges();
    }
}
