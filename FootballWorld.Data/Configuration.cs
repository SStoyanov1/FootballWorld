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
                //return;
            }

            //var categories = new List<Category>()
            //{
            //    new Category() { CategoryName = "Spain" },
            //    new Category() { CategoryName = "England" },
            //    new Category() { CategoryName = "Germany" },
            //    new Category() { CategoryName = "Others" },
            //    new Category() { CategoryName = "Bulgaria" }
            //};
            //
            //context.Categories.AddOrUpdate(categories.ToArray());
            //
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            //        }
            //    }
            //}

            base.Seed(context);
        }
    }
}
