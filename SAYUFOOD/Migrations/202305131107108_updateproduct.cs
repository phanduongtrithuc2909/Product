namespace SAYUFOOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Product", "IsHome");
            DropColumn("dbo.tb_Product", "IsHot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "IsHome", c => c.Boolean(nullable: false));
        }
    }
}
