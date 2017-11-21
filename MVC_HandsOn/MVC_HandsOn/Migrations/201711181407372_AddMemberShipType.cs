namespace MVC_HandsOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberShipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SignUpFee = c.Int(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.customers", "MemberShipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.customers", "MemberShipTypeId");
            AddForeignKey("dbo.customers", "MemberShipTypeId", "dbo.MemberShipTypes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.customers", new[] { "MemberShipTypeId" });
            DropColumn("dbo.customers", "MemberShipTypeId");
            DropTable("dbo.MemberShipTypes");
        }
    }
}
