namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestUpdateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET GenreId = 4 WHERE Id = 33");
            Sql("UPDATE Movies SET NumberInStock = 17456 WHERE Id = 33");
        }
        
        public override void Down()
        {
        }
    }
}
