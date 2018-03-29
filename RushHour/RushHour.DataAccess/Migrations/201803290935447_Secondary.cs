namespace RushHour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secondary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsEmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "ValidationCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ValidationCode");
            DropColumn("dbo.Users", "IsEmailConfirmed");
        }
    }
}
