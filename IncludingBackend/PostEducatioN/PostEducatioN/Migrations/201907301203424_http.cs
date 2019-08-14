namespace PostEducatioN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class http : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImageFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImageFile");
        }
    }
}
