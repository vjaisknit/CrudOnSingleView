namespace CrudOnSingleView.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMenu1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MenuMsts", new[] { "fk_parentId" });
            AlterColumn("dbo.MenuMsts", "fk_parentId", c => c.Int());
            CreateIndex("dbo.MenuMsts", "fk_parentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MenuMsts", new[] { "fk_parentId" });
            AlterColumn("dbo.MenuMsts", "fk_parentId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuMsts", "fk_parentId");
        }
    }
}
