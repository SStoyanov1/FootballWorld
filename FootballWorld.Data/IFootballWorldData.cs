namespace FootballWorld.Data
{
    using FootballWorld.Model;

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

        void SaveChanges();
    }
}
