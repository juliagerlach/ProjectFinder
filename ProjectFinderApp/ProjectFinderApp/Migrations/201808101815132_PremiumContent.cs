namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PremiumContent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PremiumContents", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PremiumContents", "ImageName", c => c.String());
        }
    }
}
