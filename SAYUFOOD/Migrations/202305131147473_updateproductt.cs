namespace SAYUFOOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproductt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Product", new[] { "CategoryId" });
            AddColumn("dbo.tb_Product", "Category", c => c.String(maxLength: 150));
            DropColumn("dbo.tb_Product", "CategoryId");
            DropTable("dbo.tb_Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Category",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Product", "CategoryId", c => c.Byte(nullable: false));
            DropColumn("dbo.tb_Product", "Category");
            CreateIndex("dbo.tb_Product", "CategoryId");
            AddForeignKey("dbo.tb_Product", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}
