namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmore : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, AddedToDbDate, NumberInStock, GenreId, ReleaseDate ) " +
            "VALUES ('The Beach', '2017-03-12' , 780, 2, '2000-02-11')");
        }

        public override void Down()
        {
        }
    }
}
