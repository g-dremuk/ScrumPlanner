using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Models
{
    public class MarkTaskAsSolvedModel
    {
        public List<SelectListItem> AllWorkedTask { get; set; }
        public bool isSucced { get; set; }
        public string errorMessage { get; set; }

        public MarkTaskAsSolvedModel()
        {
            AllWorkedTask = new List<SelectListItem>();
            isSucced = false;
            errorMessage = string.Empty;
        }
    }
}