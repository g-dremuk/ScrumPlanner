using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.BllRequirements;

namespace ProjectManagementSystem.Bll
{
    public class Programmer : IProgrammer
    {
        public IStorage Storage { get; set; }
        public IUsersProvider UserManager { get; set; }

        public Programmer(IStorage storage, IUsersProvider user)
        {
            if (storage == null) throw new ArgumentNullException("storage");
            if (user == null) throw new ArgumentNullException("Users Provider");
            
            Storage = storage;
            UserManager = user;
        }

        public void saveSelectedTask(int idUser, int idTask)
        {
            Storage.AddTaskToUser(idTask, idUser);
        }

        public void CheckSelectedTaskAsSolved(int taskId)
        {
            Storage.SetTaskSolved(taskId);
        }
    }
}
