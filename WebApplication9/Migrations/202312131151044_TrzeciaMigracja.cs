namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrzeciaMigracja : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Administrators", "AccountID");
            DropColumn("dbo.Students", "AccountID");
            DropColumn("dbo.Teachers", "AccountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "AccountID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "AccountID", c => c.Int(nullable: false));
            AddColumn("dbo.Administrators", "AccountID", c => c.Int(nullable: false));
        }
    }
}
