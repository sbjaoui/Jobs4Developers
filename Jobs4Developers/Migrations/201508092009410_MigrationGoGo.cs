namespace Jobs4Developers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationGoGo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Developers", "WorkExperience_Id", "dbo.WorkExperiences");
            DropIndex("dbo.Developers", new[] { "WorkExperience_Id" });
            DropColumn("dbo.Developers", "WorkExperience_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Developers", "WorkExperience_Id", c => c.Int());
            CreateIndex("dbo.Developers", "WorkExperience_Id");
            AddForeignKey("dbo.Developers", "WorkExperience_Id", "dbo.WorkExperiences", "Id");
        }
    }
}
