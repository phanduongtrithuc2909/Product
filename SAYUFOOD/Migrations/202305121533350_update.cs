namespace SAYUFOOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Product", new[] { "CategoryId" });
            AddColumn("dbo.tb_Product", "Category_Id", c => c.Int());
            AlterColumn("dbo.tb_Product", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.tb_Product", "Category_Id");
            AddForeignKey("dbo.tb_Product", "Category_Id", "dbo.tb_Category", "Id");
            DropColumn("dbo.tb_Category", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Category", "Description", c => c.String(maxLength: 500));
            DropForeignKey("dbo.tb_Product", "Category_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_Product", new[] { "Category_Id" });
            AlterColumn("dbo.tb_Product", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.tb_Product", "Category_Id");
            CreateIndex("dbo.tb_Product", "CategoryId");
            AddForeignKey("dbo.tb_Product", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}
