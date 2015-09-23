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

        public int WorkerID { get; set; }
        public virtual Worker Worker { get; set; }

        public int ActivityID { get; set; }
        public virtual Activity Activity { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public TimeSpan HoursSpent { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}