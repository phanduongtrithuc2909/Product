namespace SAYUFOOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatee : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Category", "CreateBy");
            DropColumn("dbo.tb_Category", "CreateDate");
            DropColumn("dbo.tb_Category", "ModifiedBy");
            DropColumn("dbo.tb_Category", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Category", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Category", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_Category", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Category", "CreateBy", c => c.String());
        }
    }
}
