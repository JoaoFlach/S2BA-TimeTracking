//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeTracking.MVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserActivity
    {
        public int UserActivityID { get; set; }
        public System.TimeSpan Hours { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Activity_ActivityID { get; set; }
        public Nullable<int> User_UserID { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }
    }
}
