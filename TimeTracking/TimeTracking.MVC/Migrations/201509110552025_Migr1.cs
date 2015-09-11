namespace TimeTracking.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
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
                    })
                .PrimaryKey(t => t.ActivityTypeID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserActivities",
                c => new
                    {
                        UserActivityID = c.Int(nullable: false, identity: true),
                        Hours = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false),
                        Activity_ActivityID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserActivityID)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Activity_ActivityID)
                .Index(t => t.User_UserID);
            
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
                "dbo.UserRoles",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Role_RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Role_RoleID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Role_RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActivities", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.UserRoles", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Projects", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.RoleProjects", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.RoleProjects", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.RoleActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.RoleActivities", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.Activities", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Activities", "ActivityType_ActivityTypeID", "dbo.ActivityTypes");
            DropIndex("dbo.UserRoles", new[] { "Role_RoleID" });
            DropIndex("dbo.UserRoles", new[] { "User_UserID" });
            DropIndex("dbo.RoleProjects", new[] { "Project_ProjectID" });
            DropIndex("dbo.RoleProjects", new[] { "Role_RoleID" });
            DropIndex("dbo.RoleActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.RoleActivities", new[] { "Role_RoleID" });
            DropIndex("dbo.UserActivities", new[] { "User_UserID" });
            DropIndex("dbo.UserActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.Projects", new[] { "User_UserID" });
            DropIndex("dbo.Activities", new[] { "Project_ProjectID" });
            DropIndex("dbo.Activities", new[] { "ActivityType_ActivityTypeID" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.RoleProjects");
            DropTable("dbo.RoleActivities");
            DropTable("dbo.UserActivities");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Projects");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.Activities");
        }
    }
}
