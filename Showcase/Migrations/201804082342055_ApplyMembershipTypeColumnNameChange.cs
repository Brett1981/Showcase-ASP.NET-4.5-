namespace Showcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyMembershipTypeColumnNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipLabel", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MembershipTypes", "MembershipTypes");

            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Pay as you go' where Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Monthly' where Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Quarterly' where Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipLabel = 'Yearly' where Id = 4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "MembershipTypes", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MembershipTypes", "MembershipLabel");
        }
    }
}
