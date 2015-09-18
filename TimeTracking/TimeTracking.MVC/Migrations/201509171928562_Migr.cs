namespace TimeTracking.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Turns = c.Int(nullable: false),
                        ActivityType_ActivityTypeID = c.Int(),
                        Project_ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityType_ActivityTypeID)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID)
                .Index(t => t.ActivityType_ActivityTypeID)
                .Index(t => t.Project_ProjectID);
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        ActivityTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ActivityTypeID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Deadline = c.DateTime(nullable: false),
                        Owner_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.Owner_Email)
                .Index(t => t.Owner_Email);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UserActivities",
                c => new
                    {
                        UserActivityID = c.Int(nullable: false, identity: true),
                        Hours = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false),
                        Activity_ActivityID = c.Int(),
                        User_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserActivityID)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID)
                .ForeignKey("dbo.Users", t => t.User_Email)
                .Index(t => t.Activity_ActivityID)
                .Index(t => t.User_Email);
            
            CreateTable(
                "dbo.RoleActivities",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        Activity_ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.Activity_ActivityID })
                .ForeignKey("dbo.Roles", t => t.Role_RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID, cascadeDelete: true)
                .Index(t => t.Role_RoleID)
                .Index(t => t.Activity_ActivityID);
            
            CreateTable(
                "dbo.RoleProjects",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        Project_ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.Project_ProjectID })
                .ForeignKey("dbo.Roles", t => t.Role_RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID, cascadeDelete: true)
                .Index(t => t.Role_RoleID)
                .Index(t => t.Project_ProjectID);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        User_Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.User_Email })
                .ForeignKey("dbo.Roles", t => t.Role_RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Email, cascadeDelete: true)
                .Index(t => t.Role_RoleID)
                .Index(t => t.User_Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActivities", "User_Email", "dbo.Users");
            DropForeignKey("dbo.UserActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.RoleUsers", "User_Email", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.RoleProjects", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.RoleProjects", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.RoleActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.RoleActivities", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.Projects", "Owner_Email", "dbo.Users");
            DropForeignKey("dbo.Activities", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Activities", "ActivityType_ActivityTypeID", "dbo.ActivityTypes");
            DropIndex("dbo.RoleUsers", new[] { "User_Email" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleID" });
            DropIndex("dbo.RoleProjects", new[] { "Project_ProjectID" });
            DropIndex("dbo.RoleProjects", new[] { "Role_RoleID" });
            DropIndex("dbo.RoleActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.RoleActivities", new[] { "Role_RoleID" });
            DropIndex("dbo.UserActivities", new[] { "User_Email" });
            DropIndex("dbo.UserActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.Projects", new[] { "Owner_Email" });
            DropIndex("dbo.Activities", new[] { "Project_ProjectID" });
            DropIndex("dbo.Activities", new[] { "ActivityType_ActivityTypeID" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.RoleProjects");
            DropTable("dbo.RoleActivities");
            DropTable("dbo.UserActivities");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.Activities");
        }
    }
}
