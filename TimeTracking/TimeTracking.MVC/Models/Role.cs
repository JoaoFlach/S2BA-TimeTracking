using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Role
    {
        public int RoleID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }


    }
}