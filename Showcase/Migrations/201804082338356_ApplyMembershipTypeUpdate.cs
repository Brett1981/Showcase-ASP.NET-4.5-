namespace Showcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyMembershipTypeUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipTypes", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipTypes");
        }
    }
}
