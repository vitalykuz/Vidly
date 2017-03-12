namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeTime : DbMigration
    {
        public override void Up()
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-mm-dd hh:mm:ss";

            Sql("UPDATE Movies SET AddedToDbDate = '" + time.ToString(format) + "' WHERE Id = 30");
        }
        
        public override void Down()
        {
        }
    }
}
