namespace GrowProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OderDetail_OderDetailID", "dbo.OderDetails");
            DropForeignKey("dbo.OderDetails", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.OderDetails", new[] { "Product_ProductID" });
            DropIndex("dbo.Orders", new[] { "OderDetail_OderDetailID" });
            RenameColumn(table: "dbo.OderDetails", name: "Product_ProductID", newName: "ProductID");
            DropPrimaryKey("dbo.Posts");
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
                        HomePage = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.CategoryPosts",
                c => new
                    {
                        CategoryPostID = c.String(nullable: false, maxLength: 15),
                        Titile = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryPostID);
            
            AddColumn("dbo.Posts", "PostID", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Posts", "CategoryPostID", c => c.String(maxLength: 15));
            AlterColumn("dbo.OderDetails", "OrderID", c => c.Int(nullable: false));
            AlterColumn("dbo.OderDetails", "ProductID", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Posts", "PublishDate", c => c.DateTime());
            AlterColumn("dbo.Products", "SupplierID", c => c.String(maxLength: 15));
            AlterColumn("dbo.Products", "CategoryID", c => c.String(maxLength: 15));
            AddPrimaryKey("dbo.Posts", "PostID");
            CreateIndex("dbo.Products", "SupplierID");
            CreateIndex("dbo.Products", "CategoryID");
            CreateIndex("dbo.OderDetails", "OrderID");
            CreateIndex("dbo.OderDetails", "ProductID");
            CreateIndex("dbo.Posts", "CategoryPostID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.OderDetails", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers", "SupplierID");
            AddForeignKey("dbo.Posts", "CategoryPostID", "dbo.CategoryPosts", "CategoryPostID");
            AddForeignKey("dbo.OderDetails", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            DropColumn("dbo.Orders", "OderDetail_OderDetailID");
            DropColumn("dbo.Posts", "IDPost");
            DropColumn("dbo.Posts", "IDCategorPost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "IDCategorPost", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Posts", "IDPost", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Orders", "OderDetail_OderDetailID", c => c.Int());
            DropForeignKey("dbo.OderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Posts", "CategoryPostID", "dbo.CategoryPosts");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.OderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryPostID" });
            DropIndex("dbo.OderDetails", new[] { "ProductID" });
            DropIndex("dbo.OderDetails", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Products", "CategoryID", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Products", "SupplierID", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Posts", "PublishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OderDetails", "ProductID", c => c.String(maxLength: 15));
            AlterColumn("dbo.OderDetails", "OrderID", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Posts", "CategoryPostID");
            DropColumn("dbo.Posts", "PostID");
            DropTable("dbo.CategoryPosts");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            AddPrimaryKey("dbo.Posts", "IDPost");
            RenameColumn(table: "dbo.OderDetails", name: "ProductID", newName: "Product_ProductID");
            CreateIndex("dbo.Orders", "OderDetail_OderDetailID");
            CreateIndex("dbo.OderDetails", "Product_ProductID");
            AddForeignKey("dbo.OderDetails", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Orders", "OderDetail_OderDetailID", "dbo.OderDetails", "OderDetailID");
        }
    }
}
