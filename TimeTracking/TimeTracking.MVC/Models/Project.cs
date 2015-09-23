using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

        [Display(Name = "Project Owner")]
        [Required]
        public int WorkerID { get; set; }        
        
        public virtual Worker Worker { get; set; }

        [Display(Name ="Deadline date")]
        [Required]
        public DateTime Deadline { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}