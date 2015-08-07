namespace Jobs4Developers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addoffers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Offers", new[] { "Company_Id" });
            DropTable("dbo.Offers");
        }
    }
}
