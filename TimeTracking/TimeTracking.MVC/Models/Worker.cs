using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }

        [Required]
        public string Name { get; set; }
              
        public virtual ICollection<WorkerActivity> GroupsActivities { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Project> Projects { get; set; }


    }
}