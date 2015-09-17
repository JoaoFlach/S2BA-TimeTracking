using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class WorkerActivity
    {
        public int WorkerActivityID { get; set; }

        public virtual Worker Worker { get; set; }

        public virtual Activity Activity { get; set; }

        public TimeSpan HoursSpent { get; set; }

        public DateTime Date { get; set; }
    }
}