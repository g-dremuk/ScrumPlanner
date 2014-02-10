using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Tests.Mocks
{
    public class FakeStorageForWrongIdTest : IStorage
    {
        public int AddTask(TaskInfo task)
        {
            throw new System.NotImplementedException();
        }

        public TaskInfo GetTaskById(int id)
        {
            return null;
        }

        public void UpdateTask(TaskInfo task)
        {
            throw new System.NotImplementedException();
        }

        public TaskInfo[] GetTasks()
        {
            throw new System.NotImplementedException();
        }

        public string GetUserPasswordByLogin(string login)
        {
            throw new System.NotImplementedException();
        }


        public void AddUserToRole(string userName, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public string GetUserRole(string username)
        {
            throw new System.NotImplementedException();
        }

        public bool IsUserExist(string username)
        {
            throw new System.NotImplementedException();
        }

        public void CreateUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public string GetUserPassword(string username)
        {
            throw new System.NotImplementedException();
        }


        public int GetUserIdByLogin(string login)
        {
            throw new System.NotImplementedException();
        }

        public int AddTaskToProject(TaskInfo task)
        {
            throw new System.NotImplementedException();
        }

        public void CreateProject(string createProjectName, string createProjectDescription)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(UserInfo userInfo)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<TaskInfo> GetAllTasks()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<ProjectInfo> GetAllProjects()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<UserInfo> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}