using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllRequirements;

namespace ProjectManagementSystem.UiHelper
{
    public class DateProvider : IDateProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
