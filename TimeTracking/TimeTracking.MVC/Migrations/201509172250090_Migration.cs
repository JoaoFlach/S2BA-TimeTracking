namespace TimeTracking.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleActivities", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.RoleActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.RoleProjects", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.RoleProjects", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.UserActivities", "User_UserID", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "User_UserID" });
            DropIndex("dbo.UserActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.UserActivities", new[] { "User_UserID" });
            DropIndex("dbo.RoleActivities", new[] { "Role_RoleID" });
            DropIndex("dbo.RoleActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.RoleProjects", new[] { "Role_RoleID" });
            DropIndex("dbo.RoleProjects", new[] { "Project_ProjectID" });
            DropIndex("dbo.UserRoles", new[] { "User_UserID" });
            DropIndex("dbo.UserRoles", new[] { "Role_RoleID" });
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.WorkerID);
            
            CreateTable(
                "dbo.WorkerActivities",
                c => new
                    {
                        WorkerActivityID = c.Int(nullable: false, identity: true),
                        HoursSpent = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false),
                        Activity_ActivityID = c.Int(),
                        Worker_WorkerID = c.Int(),
                    })
                .PrimaryKey(t => t.WorkerActivityID)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID)
                .ForeignKey("dbo.Workers", t => t.Worker_WorkerID)
                .Index(t => t.Activity_ActivityID)
                .Index(t => t.Worker_WorkerID);
            
            CreateTable(
                "dbo.GroupActivities",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        Activity_ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.Activity_ActivityID })
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID, cascadeDelete: true)
                .Index(t => t.Group_GroupID)
                .Index(t => t.Activity_ActivityID);
            
            CreateTable(
                "dbo.ProjectGroups",
                c => new
                    {
                        Project_ProjectID = c.Int(nullable: false),
                        Group_GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectID, t.Group_GroupID })
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .Index(t => t.Project_ProjectID)
                .Index(t => t.Group_GroupID);
            
            CreateTable(
                "dbo.WorkerGroups",
                c => new
                    {
                        Worker_WorkerID = c.Int(nullable: false),
                        Group_GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Worker_WorkerID, t.Group_GroupID })
                .ForeignKey("dbo.Workers", t => t.Worker_WorkerID, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .Index(t => t.Worker_WorkerID)
                .Index(t => t.Group_GroupID);
            
            AddColumn("dbo.Activities", "Name", c => c.String());
            AddColumn("dbo.Activities", "Description", c => c.String());
            AddColumn("dbo.ActivityTypes", "Name", c => c.String());
            AddColumn("dbo.Projects", "Deadline", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "Owner_WorkerID", c => c.Int());
            CreateIndex("dbo.Projects", "Owner_WorkerID");
            AddForeignKey("dbo.Projects", "Owner_WorkerID", "dbo.Workers", "WorkerID");
            DropColumn("dbo.Projects", "User_UserID");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.UserActivities");
            DropTable("dbo.RoleActivities");
            DropTable("dbo.RoleProjects");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Role_RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Role_RoleID });
            
            CreateTable(
                "dbo.RoleProjects",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        Project_ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.Project_ProjectID });
            
            CreateTable(
                "dbo.RoleActivities",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        Activity_ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.Activity_ActivityID });
            
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
                .PrimaryKey(t => t.UserActivityID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Projects", "User_UserID", c => c.Int());
            DropForeignKey("dbo.Projects", "Owner_WorkerID", "dbo.Workers");
            DropForeignKey("dbo.WorkerActivities", "Worker_WorkerID", "dbo.Workers");
            DropForeignKey("dbo.WorkerActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.WorkerGroups", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.WorkerGroups", "Worker_WorkerID", "dbo.Workers");
            DropForeignKey("dbo.ProjectGroups", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.ProjectGroups", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.GroupActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.GroupActivities", "Group_GroupID", "dbo.Groups");
            DropIndex("dbo.WorkerGroups", new[] { "Group_GroupID" });
            DropIndex("dbo.WorkerGroups", new[] { "Worker_WorkerID" });
            DropIndex("dbo.ProjectGroups", new[] { "Group_GroupID" });
            DropIndex("dbo.ProjectGroups", new[] { "Project_ProjectID" });
            DropIndex("dbo.GroupActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.GroupActivities", new[] { "Group_GroupID" });
            DropIndex("dbo.WorkerActivities", new[] { "Worker_WorkerID" });
            DropIndex("dbo.WorkerActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.Projects", new[] { "Owner_WorkerID" });
            DropColumn("dbo.Projects", "Owner_WorkerID");
            DropColumn("dbo.Projects", "Deadline");
            DropColumn("dbo.ActivityTypes", "Name");
            DropColumn("dbo.Activities", "Description");
            DropColumn("dbo.Activities", "Name");
            DropTable("dbo.WorkerGroups");
            DropTable("dbo.ProjectGroups");
            DropTable("dbo.GroupActivities");
            DropTable("dbo.WorkerActivities");
            DropTable("dbo.Workers");
            DropTable("dbo.Groups");
            CreateIndex("dbo.UserRoles", "Role_RoleID");
            CreateIndex("dbo.UserRoles", "User_UserID");
            CreateIndex("dbo.RoleProjects", "Project_ProjectID");
            CreateIndex("dbo.RoleProjects", "Role_RoleID");
            CreateIndex("dbo.RoleActivities", "Activity_ActivityID");
            CreateIndex("dbo.RoleActivities", "Role_RoleID");
            CreateIndex("dbo.UserActivities", "User_UserID");
            CreateIndex("dbo.UserActivities", "Activity_ActivityID");
            CreateIndex("dbo.Projects", "User_UserID");
            AddForeignKey("dbo.UserActivities", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.UserActivities", "Activity_ActivityID", "dbo.Activities", "ActivityID");
            AddForeignKey("dbo.UserRoles", "Role_RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.RoleProjects", "Project_ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.RoleProjects", "Role_RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.RoleActivities", "Activity_ActivityID", "dbo.Activities", "ActivityID", cascadeDelete: true);
            AddForeignKey("dbo.RoleActivities", "Role_RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
        }
    }
}
