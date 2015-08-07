namespace Jobs4Developers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Offers", new[] { "Company_Id" });
            RenameColumn(table: "dbo.Offers", name: "Company_Id", newName: "CompanyId");
            AlterColumn("dbo.Offers", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Offers", "CompanyId");
            AddForeignKey("dbo.Offers", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Offers", new[] { "CompanyId" });
            AlterColumn("dbo.Offers", "CompanyId", c => c.Int());
            RenameColumn(table: "dbo.Offers", name: "CompanyId", newName: "Company_Id");
            CreateIndex("dbo.Offers", "Company_Id");
            AddForeignKey("dbo.Offers", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
