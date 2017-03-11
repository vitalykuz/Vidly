namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdayColumnInCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = CAST('1986-10-04' AS DATETIME) WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
