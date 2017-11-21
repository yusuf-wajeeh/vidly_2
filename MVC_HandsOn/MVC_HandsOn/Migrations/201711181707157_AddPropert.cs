namespace MVC_HandsOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropert : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.customers", "name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.customers", "name", c => c.String());
        }
    }
}
