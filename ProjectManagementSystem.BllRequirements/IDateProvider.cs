using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagementSystem.BllRequirements
{
    public interface IDateProvider
    {
        DateTime Now { get; }
    }
}
