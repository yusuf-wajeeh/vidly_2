namespace MVC_HandsOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddName1 : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes set name='PayAsYouGo' where id=1");
            Sql("Update MemberShipTypes set name='Monthly' where id=2");
            Sql("Update MemberShipTypes set name='Quarterly' where id=3");
            Sql("Update MemberShipTypes set name='Annual' where id=4");
        }
        
        public override void Down()
        {
        }
    }
}
