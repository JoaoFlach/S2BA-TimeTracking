using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class User
    {
        public int UserID { get; set; }
                
        public string Email { get; set; }

        public virtual ICollection<UserActivity> UserActivities { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}