namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Projects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PremiumContents", "FilePath", c => c.String());
            AlterColumn("dbo.PremiumContents", "Image", c => c.Binary());
            DropColumn("dbo.Projects", "Image");
            DropColumn("dbo.PremiumContents", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PremiumContents", "FileName", c => c.String());
            AddColumn("dbo.Projects", "Image", c => c.Byte(nullable: false));
            AlterColumn("dbo.PremiumContents", "Image", c => c.Byte(nullable: false));
            DropColumn("dbo.PremiumContents", "FilePath");
        }
    }
}
