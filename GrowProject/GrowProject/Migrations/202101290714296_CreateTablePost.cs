namespace GrowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablePost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OderDetail_OderDetailID", "dbo.OderDetails");
            DropForeignKey("dbo.OderDetails", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.OderDetails", new[] { "Product_ProductID" });
            DropIndex("dbo.Orders", new[] { "OderDetail_OderDetailID" });
            RenameColumn(table: "dbo.OderDetails", name: "Product_ProductID", newName: "ProductID");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 15),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Picture = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.String(nullable: false, maxLength: 15),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        ContacName = c.String(maxLength: 30),
                        ContacTitle = c.String(maxLength: 30),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 15),
                        Region = c.String(maxLength: 15),
                        PostalCode = c.String(maxLength: 10),
                        Conuntry = c.String(maxLength: 15),
                        Phone = c.String(maxLength: 24),
                        Fax = c.String(maxLength: 24),
                        HomePage = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.CategoryPosts",
                c => new
                    {
                        IDCategoryPost = c.String(nullable: false, maxLength: 15),
                        Titile = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDCategoryPost);
            
            AddColumn("dbo.OderDetails", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Posts", "IDCategoryPost", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.OderDetails", "ProductID", c => c.String(nullable: false, maxLength: 15));
            CreateIndex("dbo.OderDetails", "ProductID");
            CreateIndex("dbo.OderDetails", "Order_OrderID");
            CreateIndex("dbo.Products", "SupplierID");
            CreateIndex("dbo.Products", "CategoryID");
            CreateIndex("dbo.Posts", "IDCategoryPost");
            AddForeignKey("dbo.OderDetails", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers", "SupplierID", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "IDCategoryPost", "dbo.CategoryPosts", "IDCategoryPost", cascadeDelete: true);
            AddForeignKey("dbo.OderDetails", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            DropColumn("dbo.Orders", "OderDetail_OderDetailID");
            DropColumn("dbo.Posts", "IDCategorPost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "IDCategorPost", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Orders", "OderDetail_OderDetailID", c => c.Int());
            DropForeignKey("dbo.OderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Posts", "IDCategoryPost", "dbo.CategoryPosts");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.OderDetails", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Posts", new[] { "IDCategoryPost" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropIndex("dbo.OderDetails", new[] { "Order_OrderID" });
            DropIndex("dbo.OderDetails", new[] { "ProductID" });
            AlterColumn("dbo.OderDetails", "ProductID", c => c.String(maxLength: 15));
            DropColumn("dbo.Posts", "IDCategoryPost");
            DropColumn("dbo.OderDetails", "Order_OrderID");
            DropTable("dbo.CategoryPosts");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            RenameColumn(table: "dbo.OderDetails", name: "ProductID", newName: "Product_ProductID");
            CreateIndex("dbo.Orders", "OderDetail_OderDetailID");
            CreateIndex("dbo.OderDetails", "Product_ProductID");
            AddForeignKey("dbo.OderDetails", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Orders", "OderDetail_OderDetailID", "dbo.OderDetails", "OderDetailID");
        }
    }
}
