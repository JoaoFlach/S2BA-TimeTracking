using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracking.MVC.Models;

namespace TimeTracking.MVC.ViewModels
{
    public class ProjectGroupsViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Group> AllGroups { get; set; }

        private List<int> _selectedGroups { get; set; }
        public List<int> SelectedGroups {
            get
            {
                if(_selectedGroups == null)
                {
                    _selectedGroups = Project.Groups.Select(g=>g.GroupID).ToList();
                }
                return _selectedGroups;
            }
            set { _selectedGroups = value; }
        }
    }
}