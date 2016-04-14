namespace RedditClone.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RedditCloneContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "RedditCloneContext";
        }

        protected override void Seed(RedditCloneContext context)
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
            context.RedditPosts.AddOrUpdate(
            p => p.Title,
            new RedditPost {Author ="Zach Ballard", PostTime = new DateTime(2016,1,1), Title="I am a great title!", Body="Blah blah blah", ImageUrl= "https://www.fillmurray.com/150/100" },
            new RedditPost { Author = "Frank Fragglestack", PostTime = new DateTime(2016, 2, 1), Title = "I am a better title!", Body = "Blah blah blah", ImageUrl = "https://www.fillmurray.com/150/100" },
            new RedditPost { Author = "Brutisy Banjopants", PostTime = new DateTime(2016, 3, 1), Title = "I AM YELLING!", Body = "BLAH BLAH BLAH", ImageUrl = "https://www.fillmurray.com/150/100" }
            );
        }
    }
}
