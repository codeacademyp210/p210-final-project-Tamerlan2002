namespace PostEducatioN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechanges03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Description", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Description");
        }
    }
}
