using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Models
{
    public class TasksListModel
    {
        public List<SelectListItem> AllTasks { get; set; }

        public TasksListModel()
        {
            AllTasks = new List<SelectListItem>();
        }
    }
}