namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Category_Identity", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "Category_Identity" });
            DropColumn("dbo.Books", "CategoryId");
            RenameColumn(table: "dbo.Books", name: "Category_Identity", newName: "CategoryId");
            AlterColumn("dbo.Books", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "CategoryId");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Identity", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            AlterColumn("dbo.Books", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "CategoryId", newName: "Category_Identity");
            AddColumn("dbo.Books", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Category_Identity");
            AddForeignKey("dbo.Books", "Category_Identity", "dbo.Categories", "Identity");
        }
    }
}
