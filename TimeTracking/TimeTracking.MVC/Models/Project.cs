using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Project
    {
        [Display(Name="Project")]
        public int ProjectID { get; set; }
        [ForeignKey("Worker")]
        public int WorkerID { get; set; } 
        [Display(Name = "Project Name")]
        [StringLength(50)]
        [Column("Name")]
        [Required]        
        public string ProjectName { get; set; }
        [Display(Name ="Deadline Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Deadline { get; set; }
                
        public virtual Worker Worker { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}