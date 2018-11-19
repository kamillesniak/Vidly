namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillGenreAndMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres  Values (1,'Romance')");
            Sql("Insert into Genres  Values (2,'Comedy')");
            Sql("Insert into Genres  Values (3,'Drama')");
            Sql("Insert into Genres  Values (4,'Action')");
            Sql("Insert into Genres  Values (5,'Family')");
            Sql("Update Movies Set GenreId = 2 where Id=1");
            Sql("Update Movies Set GenreId=1 where Id=2");
            Sql("Update Movies Set GenreId=3 where Id=3");
            Sql("Update Movies Set GenreId=3 where Id=4");
            Sql("Update Movies Set GenreId=4 where Id=5");
        }
        
        public override void Down()
        {
        }
    }
}
