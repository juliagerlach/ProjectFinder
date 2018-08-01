namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PremiumContents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PremiumContents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ProjectTitle = c.String(),
                        Technique = c.String(),
                        Supplies = c.String(),
                        FileName = c.String(),
                        Image = c.Byte(nullable: false),
                        ContactInfo = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PremiumContents", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.PremiumContents", new[] { "ApplicationUserID" });
            DropTable("dbo.PremiumContents");
        }
    }
}
