namespace EmployeeWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StreetAddress1 = c.String(),
                        StreetAddress2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address_Id = c.String(maxLength: 128),
                        Emp_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Emp_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Emp_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Emp_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Employees", new[] { "Emp_Id" });
            DropIndex("dbo.Employees", new[] { "Address_Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Addresses");
        }
    }
}
