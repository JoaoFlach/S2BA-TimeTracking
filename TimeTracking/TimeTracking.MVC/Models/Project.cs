﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.MVC.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}