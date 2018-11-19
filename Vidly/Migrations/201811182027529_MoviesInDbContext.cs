namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesInDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Genres = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Movies(Name,Genres) Values('Hangover','Comedy')");
            Sql("INSERT INTO Movies(Name,Genres) Values('Die Hard','Action')");
            Sql("INSERT INTO Movies(Name,Genres) Values('The Terminator','Action')");
            Sql("INSERT INTO Movies(Name,Genres) Values('Toy Story','Family')");
            Sql("INSERT INTO Movies(Name,Genres) Values('Titanic','Romance')");

        }

        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
