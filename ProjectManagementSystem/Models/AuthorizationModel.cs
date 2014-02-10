using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class AuthorizationModel
    {
        public bool isUserExist { get; set; }
        
        public AuthorizationModel()
        {
            isUserExist = true;    
        }
    }
}