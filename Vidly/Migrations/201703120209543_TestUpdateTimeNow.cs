namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestUpdateTimeNow : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET GenreId = 5 WHERE Id = 34");
            Sql("UPDATE Movies SET NumberInStock = 215 WHERE Id = 34");
            Sql("UPDATE Movies SET GenreId = 3 WHERE Id = 32");

            DateTime time = DateTime.Now;              
            string format = "yyyy-mm-dd hh:mm:ss";    

            Sql("UPDATE Movies SET AddedToDbDate = '" + time.ToString(format) + "' WHERE Id = 32");

        }
        
        public override void Down()
        {
        }
    }
}
