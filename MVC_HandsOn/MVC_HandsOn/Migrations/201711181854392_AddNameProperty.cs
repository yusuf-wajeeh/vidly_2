namespace MVC_HandsOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberShipTypes", "name");
        }
    }
}
