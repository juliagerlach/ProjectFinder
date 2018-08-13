namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PremiumContent1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PremiumContents", "FilePath1", c => c.String());
            AddColumn("dbo.PremiumContents", "FilePath2", c => c.String());
            DropColumn("dbo.PremiumContents", "FilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PremiumContents", "FilePath", c => c.String());
            DropColumn("dbo.PremiumContents", "FilePath2");
            DropColumn("dbo.PremiumContents", "FilePath1");
        }
    }
}
