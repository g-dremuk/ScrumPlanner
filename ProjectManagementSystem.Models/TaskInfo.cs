using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagementSystem.Models
{
    public class TaskInfo
    {
        public TaskInfo(string name, string description, int profit, int duration)
        {
            Name = name;
            Description = description;
            Profit = profit;
            Duration = duration;
        }

        public TaskInfo(string name, string description, int profit, int duration, int idProject)
        {
            Name = name;
            Description = description;
            Profit = profit;
            Duration = duration;
            IdProject = idProject;
        }

        public TaskInfo(int id, string name, string description, int profit, int duration, int idProject)
        {
            Id = id;
            Name = name;
            Description = description;
            Profit = profit;
            Duration = duration;
            IdProject = idProject;
        }

        public TaskInfo(int id, string name, string description, int profit, int duration)
        {
            Id = id;
            Name = name;
            Description = description;
            Profit = profit;
            Duration = duration;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Profit { get; set; }

        public int Duration { get; set; }

        public int IdProject { get; set; }

        public int IdUser { get; set; }

        public int NumberIteration { get; set; }

        public bool IsSolved { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Description: {2}, Profit: {3}, Duration: {4}, IdProject: {5}", Id, Name, Description, Profit, Duration, IdProject);
        }
    }
}
