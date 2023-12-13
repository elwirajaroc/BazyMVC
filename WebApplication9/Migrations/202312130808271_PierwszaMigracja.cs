namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PierwszaMigracja : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        Content = c.String(),
                        Date_published = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdministratorID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdministratorID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Subject_name = c.String(),
                        Description = c.String(),
                        TeacherID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        Start_date = c.DateTime(nullable: false),
                        End_date = c.DateTime(nullable: false),
                        Administrator_AdministratorID = c.Int(),
                        ClosedQuestion_ClosedQuestionID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .ForeignKey("dbo.Administrators", t => t.Administrator_AdministratorID)
                .ForeignKey("dbo.ClosedQuestions", t => t.ClosedQuestion_ClosedQuestionID)
                .Index(t => t.TeacherID)
                .Index(t => t.AccountID)
                .Index(t => t.Administrator_AdministratorID)
                .Index(t => t.ClosedQuestion_ClosedQuestionID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Group_number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestID = c.Int(nullable: false, identity: true),
                        Date_scheduled = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Group_GroupID = c.Int(),
                    })
                .PrimaryKey(t => t.TestID)
                .ForeignKey("dbo.Groups", t => t.Group_GroupID)
                .Index(t => t.Group_GroupID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Question_text = c.String(),
                        Points = c.Int(nullable: false),
                        TestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Tests", t => t.TestID, cascadeDelete: true)
                .Index(t => t.TestID);
            
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        TestResultID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        TestID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestResultID)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.TestID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.ClosedQuestions",
                c => new
                    {
                        ClosedQuestionID = c.Int(nullable: false, identity: true),
                        AdministratorID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClosedQuestionID);
            
            CreateTable(
                "dbo.OpenQuestions",
                c => new
                    {
                        OpenQuestionID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpenQuestionID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GroupCourses",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.Course_CourseID })
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Group_GroupID)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Courses", "ClosedQuestion_ClosedQuestionID", "dbo.ClosedQuestions");
            DropForeignKey("dbo.Courses", "Administrator_AdministratorID", "dbo.Administrators");
            DropForeignKey("dbo.Tests", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.TestResults", "TestID", "dbo.Tests");
            DropForeignKey("dbo.TestResults", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TestResults", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Questions", "TestID", "dbo.Tests");
            DropForeignKey("dbo.Students", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Students", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.GroupCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.GroupCourses", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.Courses", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Messages", "AccountID", "dbo.Accounts");
            DropIndex("dbo.GroupCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.GroupCourses", new[] { "Group_GroupID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TestResults", new[] { "GroupID" });
            DropIndex("dbo.TestResults", new[] { "TestID" });
            DropIndex("dbo.TestResults", new[] { "TeacherID" });
            DropIndex("dbo.Questions", new[] { "TestID" });
            DropIndex("dbo.Tests", new[] { "Group_GroupID" });
            DropIndex("dbo.Students", new[] { "GroupID" });
            DropIndex("dbo.Students", new[] { "AccountID" });
            DropIndex("dbo.Courses", new[] { "ClosedQuestion_ClosedQuestionID" });
            DropIndex("dbo.Courses", new[] { "Administrator_AdministratorID" });
            DropIndex("dbo.Courses", new[] { "AccountID" });
            DropIndex("dbo.Courses", new[] { "TeacherID" });
            DropIndex("dbo.Messages", new[] { "AccountID" });
            DropTable("dbo.GroupCourses");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OpenQuestions");
            DropTable("dbo.ClosedQuestions");
            DropTable("dbo.Teachers");
            DropTable("dbo.TestResults");
            DropTable("dbo.Questions");
            DropTable("dbo.Tests");
            DropTable("dbo.Students");
            DropTable("dbo.Groups");
            DropTable("dbo.Courses");
            DropTable("dbo.Administrators");
            DropTable("dbo.Messages");
            DropTable("dbo.Accounts");
        }
    }
}
