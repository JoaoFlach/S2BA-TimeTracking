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
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Deadline = c.DateTime(nullable: false),
                        Owner_WorkerID = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Workers", t => t.Owner_WorkerID)
                .Index(t => t.Owner_WorkerID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Owner_WorkerID", "dbo.Workers");
            DropForeignKey("dbo.WorkerActivities", "Worker_WorkerID", "dbo.Workers");
            DropForeignKey("dbo.WorkerActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.WorkerGroups", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.WorkerGroups", "Worker_WorkerID", "dbo.Workers");
            DropForeignKey("dbo.ProjectGroups", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.ProjectGroups", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Activities", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.GroupActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.GroupActivities", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.Activities", "ActivityType_ActivityTypeID", "dbo.ActivityTypes");
            DropIndex("dbo.WorkerGroups", new[] { "Group_GroupID" });
            DropIndex("dbo.WorkerGroups", new[] { "Worker_WorkerID" });
            DropIndex("dbo.ProjectGroups", new[] { "Group_GroupID" });
            DropIndex("dbo.ProjectGroups", new[] { "Project_ProjectID" });
            DropIndex("dbo.GroupActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.GroupActivities", new[] { "Group_GroupID" });
            DropIndex("dbo.WorkerActivities", new[] { "Worker_WorkerID" });
            DropIndex("dbo.WorkerActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.Projects", new[] { "Owner_WorkerID" });
            DropIndex("dbo.Activities", new[] { "Project_ProjectID" });
            DropIndex("dbo.Activities", new[] { "ActivityType_ActivityTypeID" });
            DropTable("dbo.WorkerGroups");
            DropTable("dbo.ProjectGroups");
            DropTable("dbo.GroupActivities");
            DropTable("dbo.WorkerActivities");
            DropTable("dbo.Workers");
            DropTable("dbo.Projects");
            DropTable("dbo.Groups");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.Activities");
        }
    }
}
