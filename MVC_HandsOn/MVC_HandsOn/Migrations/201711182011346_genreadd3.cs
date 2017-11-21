namespace MVC_HandsOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreadd3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_id" });
            RenameColumn(table: "dbo.Movies", name: "genre_id", newName: "genreid");
            AlterColumn("dbo.Movies", "genreid", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "genreid");
            AddForeignKey("dbo.Movies", "genreid", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genreid", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genreid" });
            AlterColumn("dbo.Movies", "genreid", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "genreid", newName: "genre_id");
            CreateIndex("dbo.Movies", "genre_id");
            AddForeignKey("dbo.Movies", "genre_id", "dbo.Genres", "id");
        }
    }
}
