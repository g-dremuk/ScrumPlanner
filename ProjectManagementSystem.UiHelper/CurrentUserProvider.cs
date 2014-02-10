using System;
using System.Web;
using ProjectManagementSystem.BllRequirements;

namespace ProjectManagementSystem.UiHelper
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        public CurrentUserProvider()
        {
        }

        public bool IsAdmin {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated 
                       && HttpContext.Current.User.IsInRole("admin");
            }
        }
        public string Name
        {
            get { return HttpContext.Current.User.Identity.Name ?? String.Empty; }
        }
    }
}