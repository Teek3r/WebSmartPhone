namespace WebSmartPhone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetails", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductDetails", new[] { "Product_Id" });
            DropTable("dbo.ProductDetails");
        }
    }
}
