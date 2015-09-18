using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class EntitiesContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet <WorkerActivity> WorkerActivities { get; set; }
    }
}