namespace SAYUFOOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "Category_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_Product", new[] { "Category_Id" });
            DropColumn("dbo.tb_Product", "CategoryId");
            RenameColumn(table: "dbo.tb_Product", name: "Category_Id", newName: "CategoryId");
            DropPrimaryKey("dbo.tb_Category");
            AlterColumn("dbo.tb_Category", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.tb_Product", "CategoryId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.tb_Category", "Id");
            CreateIndex("dbo.tb_Product", "CategoryId");
            AddForeignKey("dbo.tb_Product", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Product", new[] { "CategoryId" });
            DropPrimaryKey("dbo.tb_Category");
            AlterColumn("dbo.tb_Product", "CategoryId", c => c.Int());
            AlterColumn("dbo.tb_Category", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_Category", "Id");
            RenameColumn(table: "dbo.tb_Product", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.tb_Product", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.tb_Product", "Category_Id");
            AddForeignKey("dbo.tb_Product", "Category_Id", "dbo.tb_Category", "Id");
        }
    }
}
