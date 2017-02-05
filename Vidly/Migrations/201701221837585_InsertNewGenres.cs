namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertNewGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO GENRES (id,Name) VALUES (3,'Action') ");
            Sql("Insert INTO GENRES (id,Name) VALUES (4,'Documentary') ");
            Sql("Insert INTO GENRES (id,Name) VALUES (5,'Crime') ");
            Sql("Insert INTO GENRES (id,Name) VALUES (6,'Drama') ");
            Sql("Insert INTO GENRES (id,Name) VALUES (7,'History') ");
        }
        
        public override void Down()
        {
        }
    }
}
