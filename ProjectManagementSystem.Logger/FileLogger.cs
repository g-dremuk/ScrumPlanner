using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ProjectManagementSystem.LoggerInterfaces;

namespace ProjectManagementSystem.Logger
{
    public class FileLogger : ILogger
    {
        public void Write(string message)
        {
            File.AppendAllText(@"d:\log.txt", message + Environment.NewLine);
        }
    }
}
