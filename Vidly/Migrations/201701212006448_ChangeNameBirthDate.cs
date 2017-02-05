namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.Customers", "BirthdayDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirthdayDate", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
