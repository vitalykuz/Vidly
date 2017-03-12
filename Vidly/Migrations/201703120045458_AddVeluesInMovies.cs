namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVeluesInMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) " +
                "VALUES ('The Terminator', 2017-03-12, 11, 5, 1984-10-26)");
        }
        
        public override void Down()
        {
        }
    }
}
