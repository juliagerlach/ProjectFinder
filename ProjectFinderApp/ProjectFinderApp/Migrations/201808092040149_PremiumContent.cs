namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PremiumContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PremiumContents", "ImageName", c => c.String());
            DropColumn("dbo.PremiumContents", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PremiumContents", "Image", c => c.Binary());
            DropColumn("dbo.PremiumContents", "ImageName");
        }
    }
}
