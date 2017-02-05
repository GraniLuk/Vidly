namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' where id =1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' where id =2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' where id =3");
            Sql("UPDATE MembershipTypes SET Name = 'Annualy' where id =4");
        }
        
        public override void Down()
        {
        }
    }
}
