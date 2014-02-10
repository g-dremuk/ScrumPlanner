using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class AddNewUserModel
    {
        public bool isSucced { get; set; }
        public bool isUserExist { get; set; }
        public bool isInvalidPasswordLenth { get; set; }

        public AddNewUserModel()
        {
            isSucced = false;
            isUserExist = false;
            isInvalidPasswordLenth = false;
        }
    }
}