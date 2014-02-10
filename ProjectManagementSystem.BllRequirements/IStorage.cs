using ProjectManagementSystem.Models;
using System.Collections.Generic;

namespace ProjectManagementSystem.BllRequirements
{
    public interface IStorage
    {
        int AddTaskToProject(TaskInfo task);
        TaskInfo GetTaskById(int id);
        void UpdateTask(TaskInfo task);
        TaskInfo[] GetTasks();
        string GetUserPasswordByLogin(string login);

        void AddUserToRole(string userName, string roleName);

        string GetUserRole(string username);

        void CreateUser(string username, string password);

        bool IsUserExist(string username);

        string GetUserPassword(string username);

        int GetUserIdByLogin(string login);

        void CreateProject(string createProjectName, string createProjectDescription);

        void UpdateUser(UserInfo userInfo);

        List<TaskInfo> GetAllTasks();

        List<ProjectInfo> GetAllProjects();

        List<UserInfo> GetAllUsers();

        void AddTaskToUser(int idTask, int idUser);

        List<TaskInfo> GetAllTasksProjectForIteration(int idProject);
        List<TaskInfo> GetFreeTasks();

        List<TaskInfo> GetWorkTasks(int idUser);

        void SetTaskSolved(int taskId);

        int UpdateIterationCounter(int idProject);

        void SetTaskIteration(int idTask, int currentIterationNumber);

        int GetIterationCounterForProject(int idProject);

        List<TaskInfo> GetTasksInIteration(int idProject, int numberIteration);
    }
}
