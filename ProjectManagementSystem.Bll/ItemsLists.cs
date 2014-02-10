using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Bll
{
    public class ItemsLists : IItemsLists
    {
        public IStorage Storage { get; set; }

        public ItemsLists(IStorage storage)
        {
            if (storage == null) throw new ArgumentNullException("storage");

            Storage = storage;
        }

        public List<TaskInfo> GetAllTasks()
        {
            return Storage.GetAllTasks();
        }

        public List<ProjectInfo> GetAllProjects()
        {
            return Storage.GetAllProjects();
        }

        public List<UserInfo> GetAllUsers()
        {
            return Storage.GetAllUsers();
        }


        public List<TaskInfo> GetTasksForWork()
        {
            return Storage.GetFreeTasks();
        }
    }
}
