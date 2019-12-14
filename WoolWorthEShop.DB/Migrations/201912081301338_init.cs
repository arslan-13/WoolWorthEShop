namespace WoolWorthEShop.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        categoryID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "categoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "categoryID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
