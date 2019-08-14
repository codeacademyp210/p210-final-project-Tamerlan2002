namespace PostEducatioN.Migrations
{
    using PostEducatioN.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static PostEducatioN.Models.ApplicationDbContext;

    internal sealed class Configuration : DbMigrationsConfiguration<PostEducatioN.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PostEducatioN.Models.ApplicationDbContext";
        }

        protected override void Seed(PostEducatioN.Models.ApplicationDbContext context)
        {
            context.Likes.AddOrUpdate(x => x.Id,
                new Like() { Id = 1, AuthorId = "058f0669-8f94-4418-bd5a-6aaed28d9c97", VideoId = 1 }
                );
            context.Videos.AddOrUpdate(x => x.Id,
                new Video()
                {
                    Id = 1,
                    ApplicationUserId = "058f0669-8f94-4418-bd5a-6aaed28d9c97",
                    CategoryId = 1,
                    VideoPath = "Comic.mp4",
                    DateAdded = DateTime.Parse("03-07-2019"),
                    Name = "Comic dubsmash"
                }
                );
            context.Categories.AddOrUpdate(x => x.Id,
                new Category() { Id = 1, Name = "Comic", Icon = "fas fa-theater-masks" }
                );
            context.Comments.AddOrUpdate(x => x.Id,
                new Comment() { Id = 1, Text = "Very funny video", AuthorId = "99ab9ed8-3742-4c2c-b4cd-b69b79051a17",VideoId = 1 }
                );
        }
    }
}
