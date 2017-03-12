namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishInsertingValuesInMovies : DbMigration
    {
        public override void Up()
        {
            DateTime time = DateTime.Now;              // Use current time
            string format = "mm/dd/yyyy";    // modify the format depending upon input required in the column in database 
            DateTime testTime = new DateTime(1997, 12, 26);

            Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) " +
                "VALUES ('Titanic', '12/03/2017', 90, 3, '11/24/1997')");

        }
        
        public override void Down()
        {
        }
    }
}
