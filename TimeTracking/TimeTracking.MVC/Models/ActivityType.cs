using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class ActivityType
    {
        public int ActivityTypeID { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}