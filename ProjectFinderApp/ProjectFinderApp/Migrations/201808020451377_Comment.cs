namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "Project_ProjectID" });
            CreateIndex("dbo.Comments", "project_ProjectID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "project_ProjectID" });
            CreateIndex("dbo.Comments", "Project_ProjectID");
        }
    }
}
