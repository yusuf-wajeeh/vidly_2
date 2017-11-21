namespace MVC_HandsOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreadd1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        genreName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Movies", "genre_id", c => c.Int());
            CreateIndex("dbo.Movies", "genre_id");
            AddForeignKey("dbo.Movies", "genre_id", "dbo.Genres", "id");
            DropColumn("dbo.Movies", "genre_genreName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "genre_genreName", c => c.String());
            DropForeignKey("dbo.Movies", "genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_id" });
            DropColumn("dbo.Movies", "genre_id");
            DropTable("dbo.Genres");
        }
    }
}
