using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagementSystem.Models
{
    public class ProjectInfo
    {
        public ProjectInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public ProjectInfo(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CountIteration { get; set; }
    }
}
