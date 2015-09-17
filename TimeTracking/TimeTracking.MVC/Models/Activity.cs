using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<WorkerActivity> WorkerActivities { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    } 
}