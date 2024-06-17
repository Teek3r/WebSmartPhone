namespace WebSmartPhone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetails", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductDetails", new[] { "Product_Id" });
            DropTable("dbo.ProductDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductDetailId = c.Int(nullable: false),
                        ProductDetailName = c.String(),
                        ProductDetailDescription = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ProductDetails", "Product_Id");
            AddForeignKey("dbo.ProductDetails", "Product_Id", "dbo.Products", "Id");
        }
    }
}
