namespace WebSmartPhone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aqwert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Carts", "Product_Id");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
