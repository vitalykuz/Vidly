namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genres SET Name = 'Romantic' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
