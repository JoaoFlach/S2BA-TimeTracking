namespace TimeTracking.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Owner_Email", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Email", "dbo.Users");
            DropForeignKey("dbo.UserActivities", "User_Email", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "Owner_Email" });
            DropIndex("dbo.UserActivities", new[] { "User_Email" });
            DropIndex("dbo.RoleUsers", new[] { "User_Email" });
            RenameColumn(table: "dbo.Projects", name: "Owner_Email", newName: "Owner_UserID");
            RenameColumn(table: "dbo.RoleUsers", name: "User_Email", newName: "User_UserID");
            RenameColumn(table: "dbo.UserActivities", name: "User_Email", newName: "User_UserID");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.RoleUsers");
            AlterColumn("dbo.Projects", "Owner_UserID", c => c.Int());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserActivities", "User_UserID", c => c.Int());
            AlterColumn("dbo.RoleUsers", "User_UserID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "UserID");
            AddPrimaryKey("dbo.RoleUsers", new[] { "Role_RoleID", "User_UserID" });
            CreateIndex("dbo.Projects", "Owner_UserID");
            CreateIndex("dbo.UserActivities", "User_UserID");
            CreateIndex("dbo.RoleUsers", "User_UserID");
            AddForeignKey("dbo.Projects", "Owner_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.RoleUsers", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.UserActivities", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActivities", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Projects", "Owner_UserID", "dbo.Users");
            DropIndex("dbo.RoleUsers", new[] { "User_UserID" });
            DropIndex("dbo.UserActivities", new[] { "User_UserID" });
            DropIndex("dbo.Projects", new[] { "Owner_UserID" });
            DropPrimaryKey("dbo.RoleUsers");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.RoleUsers", "User_UserID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserActivities", "User_UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Projects", "Owner_UserID", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.RoleUsers", new[] { "Role_RoleID", "User_Email" });
            AddPrimaryKey("dbo.Users", "Email");
            RenameColumn(table: "dbo.UserActivities", name: "User_UserID", newName: "User_Email");
            RenameColumn(table: "dbo.RoleUsers", name: "User_UserID", newName: "User_Email");
            RenameColumn(table: "dbo.Projects", name: "Owner_UserID", newName: "Owner_Email");
            CreateIndex("dbo.RoleUsers", "User_Email");
            CreateIndex("dbo.UserActivities", "User_Email");
            CreateIndex("dbo.Projects", "Owner_Email");
            AddForeignKey("dbo.UserActivities", "User_Email", "dbo.Users", "Email");
            AddForeignKey("dbo.RoleUsers", "User_Email", "dbo.Users", "Email", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "Owner_Email", "dbo.Users", "Email");
        }
    }
}
