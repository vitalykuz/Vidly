namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPropertiesToMovieAndDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        ReleaseDateTime = c.DateTime(nullable: false),
                        AddedToDbDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
