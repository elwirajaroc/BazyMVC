namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrugaMigracja : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Courses", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Students", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Messages", new[] { "AccountID" });
            DropIndex("dbo.Courses", new[] { "AccountID" });
            DropIndex("dbo.Students", new[] { "AccountID" });
            AddColumn("dbo.Messages", "SenderAccount_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Courses", "Acccount_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Students", "Account_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Courses", "Acccount_Id");
            CreateIndex("dbo.Messages", "SenderAccount_Id");
            CreateIndex("dbo.Students", "Account_Id");
            AddForeignKey("dbo.Messages", "SenderAccount_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Courses", "Acccount_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Students", "Account_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.Accounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AccountID);
            
            DropForeignKey("dbo.Students", "Account_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Acccount_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SenderAccount_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "Account_Id" });
            DropIndex("dbo.Messages", new[] { "SenderAccount_Id" });
            DropIndex("dbo.Courses", new[] { "Acccount_Id" });
            DropColumn("dbo.Students", "Account_Id");
            DropColumn("dbo.Courses", "Acccount_Id");
            DropColumn("dbo.Messages", "SenderAccount_Id");
            CreateIndex("dbo.Students", "AccountID");
            CreateIndex("dbo.Courses", "AccountID");
            CreateIndex("dbo.Messages", "AccountID");
            AddForeignKey("dbo.Students", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
        }
    }
}
