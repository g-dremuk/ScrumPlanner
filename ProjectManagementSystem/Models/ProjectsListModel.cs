using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Models
{
    public class ProjectsListModel
    {
        public List<SelectListItem> AllProjects { get; set; }

        public ProjectsListModel()
        {
            AllProjects = new List<SelectListItem>();
        }
    }
}