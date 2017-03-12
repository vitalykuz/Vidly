namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDublicateRows : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movies WHERE Id = 6 ");
        }
        
        public override void Down()
        {
        }
    }
}
