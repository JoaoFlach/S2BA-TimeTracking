using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class User
    {
        public int UserID { get; set; }

        public virtual ICollection<UserActivity> UserActivities { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Project> Projects { get; set; }


    }
}