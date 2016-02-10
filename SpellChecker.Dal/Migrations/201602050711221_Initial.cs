namespace SpellChecker.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.MyUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.MyRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SearchTags",
                c => new
                    {
                        SearchTagId = c.Int(nullable: false, identity: true),
                        SpellingBeeTestId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.SearchTagId)
                .ForeignKey("dbo.SpellingBeeTests", t => t.SpellingBeeTestId, cascadeDelete: true)
                .Index(t => t.SpellingBeeTestId);
            
            CreateTable(
                "dbo.SpellingBeeTests",
                c => new
                    {
                        SpellingBeeTestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SpellingBeeTestId);
            
            CreateTable(
                "dbo.UserTests",
                c => new
                    {
                        UserTestId = c.Int(nullable: false, identity: true),
                        SpellingBeeTestId = c.Int(nullable: false),
                        TestDate = c.DateTime(nullable: false),
                        ScorePercentage = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserTestId)
                .ForeignKey("dbo.SpellingBeeTests", t => t.SpellingBeeTestId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.SpellingBeeTestId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.TestWords",
                c => new
                    {
                        TestWordId = c.Int(nullable: false, identity: true),
                        WordId = c.Int(nullable: false),
                        UserTestId = c.Int(nullable: false),
                        Correct = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TestWordId)
                .ForeignKey("dbo.UserTests", t => t.UserTestId, cascadeDelete: true)
                .Index(t => t.UserTestId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                "dbo.MyUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MyUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        WordId = c.Int(nullable: false, identity: true),
                        EnglishText = c.String(),
                        SwedishText = c.String(),
                        SpellingBeeTestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WordId)
                .ForeignKey("dbo.SpellingBeeTests", t => t.SpellingBeeTestId, cascadeDelete: true)
                .Index(t => t.SpellingBeeTestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "SpellingBeeTestId", "dbo.SpellingBeeTests");
            DropForeignKey("dbo.UserTests", "ApplicationUserId", "dbo.Users");
            DropForeignKey("dbo.MyUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.MyUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.MyUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.TestWords", "UserTestId", "dbo.UserTests");
            DropForeignKey("dbo.UserTests", "SpellingBeeTestId", "dbo.SpellingBeeTests");
            DropForeignKey("dbo.SearchTags", "SpellingBeeTestId", "dbo.SpellingBeeTests");
            DropForeignKey("dbo.MyUserRoles", "RoleId", "dbo.MyRoles");
            DropIndex("dbo.Words", new[] { "SpellingBeeTestId" });
            DropIndex("dbo.MyUserLogins", new[] { "UserId" });
            DropIndex("dbo.MyUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.TestWords", new[] { "UserTestId" });
            DropIndex("dbo.UserTests", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserTests", new[] { "SpellingBeeTestId" });
            DropIndex("dbo.SearchTags", new[] { "SpellingBeeTestId" });
            DropIndex("dbo.MyUserRoles", new[] { "RoleId" });
            DropIndex("dbo.MyUserRoles", new[] { "UserId" });
            DropIndex("dbo.MyRoles", "RoleNameIndex");
            DropTable("dbo.Words");
            DropTable("dbo.MyUserLogins");
            DropTable("dbo.MyUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.TestWords");
            DropTable("dbo.UserTests");
            DropTable("dbo.SpellingBeeTests");
            DropTable("dbo.SearchTags");
            DropTable("dbo.MyUserRoles");
            DropTable("dbo.MyRoles");
        }
    }
}
