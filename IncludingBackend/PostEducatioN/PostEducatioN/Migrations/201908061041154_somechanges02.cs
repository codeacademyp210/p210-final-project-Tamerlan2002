namespace PostEducatioN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechanges02 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Videos", "LikeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "LikeId", c => c.Int(nullable: false));
        }
    }
}
