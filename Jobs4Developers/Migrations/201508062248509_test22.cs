namespace Jobs4Developers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Description = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false),
                        Adresse = c.String(),
                        UrlLogo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Description = c.String(),
                        ProfessionalInfo = c.String(),
                        Email = c.String(nullable: false),
                        Adresse = c.String(),
                        UrlImg = c.String(),
                        Developer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.Developer_Id)
                .Index(t => t.Developer_Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniversityName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Developer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.Developer_Id)
                .Index(t => t.Developer_Id);
            
            CreateTable(
                "dbo.LanguageCompanies",
                c => new
                    {
                        Language_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language_Id, t.Company_Id })
                .ForeignKey("dbo.Languages", t => t.Language_Id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Language_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.DeveloperLanguages",
                c => new
                    {
                        Developer_Id = c.Int(nullable: false),
                        Language_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Developer_Id, t.Language_Id })
                .ForeignKey("dbo.Developers", t => t.Developer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language_Id, cascadeDelete: true)
                .Index(t => t.Developer_Id)
                .Index(t => t.Language_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeveloperLanguages", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.DeveloperLanguages", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.Educations", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.Developers", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.LanguageCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.LanguageCompanies", "Language_Id", "dbo.Languages");
            DropIndex("dbo.DeveloperLanguages", new[] { "Language_Id" });
            DropIndex("dbo.DeveloperLanguages", new[] { "Developer_Id" });
            DropIndex("dbo.LanguageCompanies", new[] { "Company_Id" });
            DropIndex("dbo.LanguageCompanies", new[] { "Language_Id" });
            DropIndex("dbo.Educations", new[] { "Developer_Id" });
            DropIndex("dbo.Developers", new[] { "Developer_Id" });
            DropTable("dbo.DeveloperLanguages");
            DropTable("dbo.LanguageCompanies");
            DropTable("dbo.Educations");
            DropTable("dbo.Developers");
            DropTable("dbo.Languages");
            DropTable("dbo.Companies");
        }
    }
}
