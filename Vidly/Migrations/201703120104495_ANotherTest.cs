namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ANotherTest : DbMigration
    {
        public override void Up()
        {
            DateTime time = DateTime.Now;              // Use current time
            string format = "yyyy-mm-dd hh:mm:ss";    // modify the format depending upon input required in the column in database 
            //string insert = @" insert into Table(DateTime Column) values ('" + time.ToString(format) + "')";
            //Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) VALUES ('Hangover', '" + time.ToString(format) + "', 20, 1, '2003/11/23')");

            Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) " +
            "VALUES ('The Test Movie 2', '" + time.ToString(format) + "' , 780, 2, '1995-12-26')");
        }
        
        public override void Down()
        {
        }
    }
}
