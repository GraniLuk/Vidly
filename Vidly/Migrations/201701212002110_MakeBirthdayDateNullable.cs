namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBirthdayDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthdayDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthdayDate", c => c.DateTime(nullable: false));
        }
    }
}
