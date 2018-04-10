namespace Showcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyMembershipTypesUPDATE : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Pay as you go' where Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Monthly' where Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Quarterly' where Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Yearly' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
