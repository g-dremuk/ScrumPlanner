using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.LoggerInterfaces;

namespace ProjectManagementSystem.Logger
{
    public class EmptyLogger : ILogger
    {
        public void Write(string message)
        {
            
        }
    }
}
