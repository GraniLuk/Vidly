using System.Web.UI.WebControls;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO GENRES (Id, Name) VALUES (2, 'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
