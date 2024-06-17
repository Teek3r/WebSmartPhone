namespace WebSmartPhone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add44 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        DetailId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetailId)
                .ForeignKey("dbo.Products", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetails", "Id", "dbo.Products");
            DropIndex("dbo.ProductDetails", new[] { "Id" });
            DropTable("dbo.ProductDetails");
        }
    }
}
