namespace PostEducatioN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somchangesadded01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(unicode: false, storeType: "text"),
                        AuthorId = c.String(),
                        VideoId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.VideoId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VideoPath = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        LikeId = c.Int(nullable: false),
                        ImagePath = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(),
                        VideoId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.VideoId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Likes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Videos", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Videos", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Likes", new[] { "VideoId" });
            DropIndex("dbo.Videos", new[] { "CategoryId" });
            DropIndex("dbo.Videos", new[] { "ApplicationUserId" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comments", new[] { "VideoId" });
            DropTable("dbo.Likes");
            DropTable("dbo.Videos");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
