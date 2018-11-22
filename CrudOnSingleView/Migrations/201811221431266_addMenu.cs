namespace CrudOnSingleView.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.MenuMsts",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuText = c.String(),
                        fk_parentId = c.Int(nullable: false),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        AreaName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.MenuMsts", t => t.fk_parentId)
                .Index(t => t.fk_parentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuMsts", "fk_parentId", "dbo.MenuMsts");
            DropIndex("dbo.MenuMsts", new[] { "fk_parentId" });
            DropTable("dbo.MenuMsts");
            DropTable("dbo.Employees");
        }
    }
}
