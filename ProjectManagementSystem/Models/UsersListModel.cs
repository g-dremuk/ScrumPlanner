using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Models
{
    public class UsersListModel
    {
        public List<SelectListItem> AllUsers { get; set; }

        public UsersListModel()
        {
            AllUsers = new List<SelectListItem>();
        }
    }
}