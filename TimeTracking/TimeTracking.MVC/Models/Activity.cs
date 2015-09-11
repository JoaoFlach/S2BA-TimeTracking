using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }

        public virtual ICollection<UserActivity> UserActivities { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    } 
}