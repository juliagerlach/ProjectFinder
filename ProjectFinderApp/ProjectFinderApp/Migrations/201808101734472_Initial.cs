namespace ProjectFinderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Role = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        PageNumber = c.Int(nullable: false),
                        ProjectTitle = c.String(),
                        ProjectType = c.String(),
                        ProjectDesigner = c.String(),
                        MagazineID = c.Int(nullable: false),
                        IssueID = c.Int(nullable: false),
                        Technique = c.String(),
                        Supplies = c.String(),
                        OnlineLink = c.String(),
                        FilePath = c.String(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Magazines", t => t.MagazineID, cascadeDelete: true)
                .Index(t => t.MagazineID);
            
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        MagazineID = c.Int(nullable: false, identity: true),
                        MagazineTitle = c.String(),
                    })
                .PrimaryKey(t => t.MagazineID);
            
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 225),
                        ContentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.PremiumContents", t => t.ContentID, cascadeDelete: true)
                .Index(t => t.ContentID);
            
            CreateTable(
                "dbo.PremiumContents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ProjectTitle = c.String(),
                        Technique = c.String(),
                        Supplies = c.String(),
                        FilePath = c.String(),
                        ImageName = c.String(),
                        ContactInfo = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        PaidAmt = c.Int(),
                        PaymentDate = c.DateTime(nullable: false),
                        SubscriberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Subscribers", t => t.SubscriberID, cascadeDelete: true)
                .Index(t => t.SubscriberID);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        SubscriberID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Email = c.String(),
                        SubscriptionType = c.String(),
                        SubscriptionStartDate = c.DateTime(nullable: false),
                        SubscriptionEndDate = c.DateTime(nullable: false),
                        Payment = c.Int(nullable: false),
                        SubscriptionActive = c.Boolean(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SubscriberID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        AccessStartDate = c.DateTime(nullable: false),
                        AccessEndDate = c.DateTime(nullable: false),
                        AccessActive = c.Boolean(nullable: false),
                        AccessType = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RegisteredUsers", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "SubscriberID", "dbo.Subscribers");
            DropForeignKey("dbo.Subscribers", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.FilePaths", "ContentID", "dbo.PremiumContents");
            DropForeignKey("dbo.PremiumContents", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "MagazineID", "dbo.Magazines");
            DropForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RegisteredUsers", new[] { "ApplicationUserID" });
            DropIndex("dbo.Subscribers", new[] { "ApplicationUserID" });
            DropIndex("dbo.Payments", new[] { "SubscriberID" });
            DropIndex("dbo.PremiumContents", new[] { "ApplicationUserID" });
            DropIndex("dbo.FilePaths", new[] { "ContentID" });
            DropIndex("dbo.Projects", new[] { "MagazineID" });
            DropIndex("dbo.Comments", new[] { "ProjectID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Admins", new[] { "ApplicationUserID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Payments");
            DropTable("dbo.PremiumContents");
            DropTable("dbo.FilePaths");
            DropTable("dbo.Magazines");
            DropTable("dbo.Projects");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Admins");
        }
    }
}
