using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Models
{
    public class ShowCurrentIterationForProject
    {
        public List<SelectListItem> tasksForIteration { get; set; }
        public List<SelectListItem> AllProjects { get; set; }

        public ShowCurrentIterationForProject()
        {
            tasksForIteration = new List<SelectListItem>();
            AllProjects = new List<SelectListItem>();
        }
    }
}