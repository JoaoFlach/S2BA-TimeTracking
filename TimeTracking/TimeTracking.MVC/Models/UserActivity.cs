using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class UserActivity
    {
        public int UserActivityID { get; set; }

        public virtual User User { get; set; }

        public virtual Activity Activity { get; set; }

        public TimeSpan Hours { get; set; }

        public DateTime Date { get; set; }
    }
}