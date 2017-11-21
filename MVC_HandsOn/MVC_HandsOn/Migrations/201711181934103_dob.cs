namespace MVC_HandsOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.customers", "dob");
        }
    }
}
