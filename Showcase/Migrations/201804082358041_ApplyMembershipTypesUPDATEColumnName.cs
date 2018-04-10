namespace Showcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyMembershipTypesUPDATEColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MembershipTypes", "MembershipLabel");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "MembershipLabel", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
