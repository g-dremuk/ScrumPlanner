using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllRequirements;

namespace ProjectManagementSystem.Debugging
{
    public class DebuggingDateProvider : IDateProvider
    {
        public DateTime Now { get { return new DateTime(2014, 5, 17, 21, 14, 28);} }
    }
}
