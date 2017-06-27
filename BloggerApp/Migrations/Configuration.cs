namespace BloggerApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BloggerApp.Models.BloggerAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BloggerApp.Models.BloggerAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Blogs.AddOrUpdate(
                new Models.Blog { Id = 1, Title = "Cool Blog Title", Content = "Some super cool content here..." },
                new Models.Blog { Id = 2, Title = "Awesome Blog Title", Content = "Some super awesome content here..." },
                new Models.Blog { Id = 3, Title = "Sweet Blog Title", Content = "Some super sweet content here..." }
            );
        }
    }
}
