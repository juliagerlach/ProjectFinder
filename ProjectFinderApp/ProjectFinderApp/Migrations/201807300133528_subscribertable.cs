namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscribertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscribers", "Payment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscribers", "Payment");
        }
    }
}
