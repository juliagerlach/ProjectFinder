namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PremiumContent2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PremiumContents", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PremiumContents", "FileName");
        }
    }
}
