namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        Project_ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID)
                .Index(t => t.Project_ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Project_ProjectID", "dbo.Projects");
            DropIndex("dbo.Comments", new[] { "Project_ProjectID" });
            DropTable("dbo.Comments");
        }
    }
}
