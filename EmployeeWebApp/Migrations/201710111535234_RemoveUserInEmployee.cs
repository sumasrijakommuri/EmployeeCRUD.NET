namespace EmployeeWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserInEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Emp_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "Emp_Id" });
            DropColumn("dbo.Employees", "Emp_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Emp_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "Emp_Id");
            AddForeignKey("dbo.Employees", "Emp_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
