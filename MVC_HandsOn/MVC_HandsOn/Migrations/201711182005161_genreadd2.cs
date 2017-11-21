namespace MVC_HandsOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreadd2 : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(genreName) values('Comedy')");
            Sql("insert into Genres(genreName) values('Romantic')");
            Sql("insert into Genres(genreName) values('Action')");
            Sql("insert into Genres(genreName) values('Family')");
        }
        
        public override void Down()
        {
        }
    }
}
