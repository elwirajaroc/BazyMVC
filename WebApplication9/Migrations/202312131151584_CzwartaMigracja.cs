namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CzwartaMigracja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Administrators", "AccountID", c => c.Guid(nullable: false));
            AddColumn("dbo.Students", "AccountID", c => c.Guid(nullable: false));
            AddColumn("dbo.Teachers", "AccountID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "AccountID");
            DropColumn("dbo.Students", "AccountID");
            DropColumn("dbo.Administrators", "AccountID");
        }
    }
}
