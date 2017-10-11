namespace EmployeeWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuickFixEmployeetable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Employees", new[] { "Address_Id" });
            AlterColumn("dbo.Employees", "Address_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Employees", "Address_Id");
            AddForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Employees", new[] { "Address_Id" });
            AlterColumn("dbo.Employees", "Address_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "Address_Id");
            AddForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
