namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InserValuesInMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) VALUES ('Hangover', '2017/02/12', 20, 1, '2017/02/12')");
        }
        
        public override void Down()
        {
        }
    }
}

//DateTime time = DateTime.Now;              // Use current time
//string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
//string insert = "INSERT INTO Movies( Name, AddedToDbDate, NumberInStock, ReleaseDate ) VALUES (1, 'Hangover', '2012-02-21T18:10:00',  '2012-02-21T18:10:00')";

//Sql(insert);