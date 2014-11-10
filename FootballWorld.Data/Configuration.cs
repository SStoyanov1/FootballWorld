namespace FootballWorld.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FootballWorld.Model;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

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

            var categories = new List<Category>()
            {
                new Category() { CategoryName = "Spanish football" },
                new Category() { CategoryName = "English football" },
                new Category() { CategoryName = "German football" },
                new Category() { CategoryName = "Italian football" },
                new Category() { CategoryName = "Bulgarian football" }
            };

            context.Categories.AddOrUpdate(categories.ToArray());

            var articles = new List<Article>() {
                new Article() { Title = "Лудогорец измъкна паметна победа срещу Базел и излезе втори", Subtitle = "Клубът постигна първа победа за България в групите", Content = "Съдържание" , DateCreated = DateTime.Now },
                new Article() { Title = "Statiya1", Subtitle = "Втора статия", Content = "Sudurjanieeee1", DateCreated = DateTime.Now },
                new Article() { Title = "Statiya2", Subtitle = "Трета статия", Content = "Sudurjanieeee2", DateCreated = DateTime.Now }
            };

            articles[0].Categories.Add(categories[0]);
            articles[0].Categories.Add(categories[1]);
            
            context.Articles.AddOrUpdate(articles.ToArray());

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            base.Seed(context);
        }
    }
}
