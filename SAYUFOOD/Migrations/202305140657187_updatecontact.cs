namespace SAYUFOOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecontact : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Contact", "IsRead");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Contact", "IsRead", c => c.Boolean(nullable: false));
        }
    }
}
