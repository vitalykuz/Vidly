namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalAddingMovies : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) " +
                "VALUES ('The Revenant', '2017-03-12', 3, 2, '2015-12-16')");
            Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) " +
                "VALUES ('The Wolf of Wall Street', '2017-03-12', 43, 2, '2013-08-04')");
        }

        public override void Down()
        {
        }
    }
}
