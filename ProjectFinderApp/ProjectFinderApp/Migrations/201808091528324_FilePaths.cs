namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePaths : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FilePaths", "PremiumContent_ContentID", c => c.Int());
            AlterColumn("dbo.FilePaths", "FileName", c => c.String(maxLength: 225));
            CreateIndex("dbo.FilePaths", "PremiumContent_ContentID");
            AddForeignKey("dbo.FilePaths", "PremiumContent_ContentID", "dbo.PremiumContents", "ContentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "PremiumContent_ContentID", "dbo.PremiumContents");
            DropIndex("dbo.FilePaths", new[] { "PremiumContent_ContentID" });
            AlterColumn("dbo.FilePaths", "FileName", c => c.String());
            DropColumn("dbo.FilePaths", "PremiumContent_ContentID");
        }
    }
}
