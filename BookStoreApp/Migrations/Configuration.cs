namespace BookStoreApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStoreApp.Models.BookStoreAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStoreApp.Models.BookStoreAppContext context)
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

            context.Authors.AddOrUpdate(
                new Models.Author { Id = 1, Name = "Stephen King" },
                new Models.Author { Id = 2, Name = "Jon Skeet" }
            );
            context.Books.AddOrUpdate(
                new Models.Book { Id = 1, Title = "IT", Price = 22.99m, Year = 1989, AuthorId = 1},
                new Models.Book { Id = 1, Title = "Salem's Lot", Price = 2.99m, Year = 1999, AuthorId = 1 },
                new Models.Book { Id = 1, Title = "C# In Depth", Price = 52.99m, Year = 2011, AuthorId = 2 },
                new Models.Book { Id = 1, Title = "Groovey In Action", Price = 52.99m, Year = 2012, AuthorId = 2 }
            );
        }
    }
}
