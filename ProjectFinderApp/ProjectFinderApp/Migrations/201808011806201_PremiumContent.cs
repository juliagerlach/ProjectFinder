namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PremiumContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Image", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Image");
        }
    }
}
