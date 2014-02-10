using System;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Tests.Mocks
{
    internal class FakeStorageForAddTask : IStorage
    {
        private TaskInfo _addedTask;

        public TaskInfo AddedTask
        {
            get { return _addedTask; }
        }

        public int AddTask(TaskInfo task)
        {
            _addedTask = task;
            task.Id = 10;
            return task.Id;
        }

        public TaskInfo GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(TaskInfo task)
        {
            throw new NotImplementedException();
        }

        public TaskInfo[] GetTasks()
        {
            throw new NotImplementedException();
        }

        public string GetUserPasswordByLogin(string login)
        {
            throw new NotImplementedException();
        }


        public void AddUserToRole(string userName, string roleName)
        {
            throw new NotImplementedException();
        }

        public string GetUserRole(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(string username)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string GetUserPassword(string username)
        {
            throw new NotImplementedException();
        }


        public int GetUserIdByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}