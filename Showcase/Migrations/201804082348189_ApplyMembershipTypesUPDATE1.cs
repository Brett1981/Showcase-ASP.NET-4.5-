namespace Showcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyMembershipTypesUPDATE1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Pay as you go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
