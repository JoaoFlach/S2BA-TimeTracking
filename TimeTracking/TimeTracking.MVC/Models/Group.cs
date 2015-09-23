using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Group
    {
        public int GroupID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }


    }
}