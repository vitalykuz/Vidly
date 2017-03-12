namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StillAddingValuesInMovies : DbMigration
    {
        public override void Up()
        {
            DateTime time = DateTime.Now;              // Use current time
            string format = "mm/dd/yyyy";    // modify the format depending upon input required in the column in database 
            DateTime testTime = new DateTime(26, 10, 1984);
            Console.Write(time.Date);

            Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) " +
                "VALUES ('The Terminator', '" + time.ToString(format) + "', 11, 5, '1984/10/26')");
        }

        public override void Down()
        {
        }
    }
}
