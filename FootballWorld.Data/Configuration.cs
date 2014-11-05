namespace FootballWorld.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FootballWorld.Model;
    using System.Collections.Generic;

    public class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Articles.Any())
            {
                return;
            }

            var articles = new List<Article>() {
                new Article() { Title = "Statiya", Content = "Sudurjanieeee", DateCreated = DateTime.Now },
                new Article() { Title = "Statiya1", Content = "Sudurjanieeee1", DateCreated = DateTime.Now },
                new Article() { Title = "Statiya2", Content = "Sudurjanieeee2", DateCreated = DateTime.Now }
            };

            context.Articles.AddOrUpdate(articles.ToArray());

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
