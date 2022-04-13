namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeBookInCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookInCategories", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookInCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.BookInCategories", new[] { "CategoryId" });
            DropIndex("dbo.BookInCategories", new[] { "BookId" });
            AddColumn("dbo.Books", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "CategoryId");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropTable("dbo.BookInCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookInCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropColumn("dbo.Books", "CategoryId");
            CreateIndex("dbo.BookInCategories", "BookId");
            CreateIndex("dbo.BookInCategories", "CategoryId");
            AddForeignKey("dbo.BookInCategories", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.BookInCategories", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
