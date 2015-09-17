using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

        public virtual Worker Owner { get; set; }

        public DateTime Deadline { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}