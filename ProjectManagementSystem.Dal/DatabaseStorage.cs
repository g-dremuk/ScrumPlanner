using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Dal.DatabaseModels;
using ProjectManagementSystem.Dal.Translators;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Dal
{
    public class DatabaseStorage : IStorage
    {
        protected ProjectManagementSystemEntities CreateContext()
        {
            return new ProjectManagementSystemEntities();
        }

        public int AddTaskToProject(TaskInfo task)
        {
            using (var context = CreateContext())
            {
                var dbTask = TaskTranslator.FromTaskInfo(task, false);
                context.Tasks.AddObject(dbTask);
                context.SaveChanges();
                return dbTask.Id;
            }
        }

        public TaskInfo GetTaskById(int id)
        {
            using (var context = CreateContext())
            {
                var task = context.Tasks.FirstOrDefault(it => it.Id == id);
                var result = TaskTranslator.ToTaskInfo(task);
                return result;
            }
        }

        public void UpdateTask(TaskInfo task)
        {
            using (var context = CreateContext())
            {
                var dbTask = new Task();
                dbTask.Id = task.Id;
                context.Tasks.Attach(dbTask);
                TaskTranslator.CopyTaskInfoToTask(task, dbTask);
                context.SaveChanges();
            }
        }

        public TaskInfo[] GetTasks()
        {
            using (var context = CreateContext())
            {
                var tasks = context.Tasks.OrderBy(it => it.Name).ToArray();

                var result = TaskTranslator.ToTaskInfo(tasks);
                return result;
            }
        }

        public string GetUserPasswordByLogin(string login)
        {
            using (var context = CreateContext())
            {
                var pwd = context.Users.Where(it => it.Login == login).Select(it => it.Password).FirstOrDefault();
                return pwd;
            }
        }

        public string UserOrganization(string name)
        {
            throw new NotImplementedException();
        }

        public void AddUserToRole(string userName, string roleName)
        {
            using (var context = CreateContext())
            {
                var user = context.Users.Where(it => it.Login == userName).FirstOrDefault();

                user.RoleId = context.Roles.Where(it => it.Name == roleName).FirstOrDefault().Id;

                context.SaveChanges();
            }
        }

        public string GetUserRole(string username)
        {
            using (var context = CreateContext())
            {
                return context.Users.Where(it => it.Login == username).FirstOrDefault().Role.ToString();
            }
        }

        public bool IsUserExist(string username)
        {
            using (var context = CreateContext())
            {
                return context.Users.Where(it => it.Login == username).Count() != 0;
            }
        }

        public void CreateUser(string username, string password)
        {
            using (var context = CreateContext())
            {
                User user = new User();

                user.Login = username;
                user.Password = password;

                context.Users.AddObject(user);
                context.SaveChanges();
            }
        }

        public string GetUserPassword(string username)
        {
            using (var context = CreateContext())
            {
                return context.Users.Where(it => it.Login == username).FirstOrDefault().Password.ToString();
            }
        }

        public int GetUserIdByLogin(string login)
        {
            using (var context = CreateContext())
            {
                return context.Users.Where(it => it.Login == login).FirstOrDefault().Id;
            }
        }

        public void CreateProject(string createProjectName, string createProjectDescription)
        {
            using (var context = CreateContext())
            {
                var dbProject = new Project();
                dbProject.Name = createProjectName;
                dbProject.Description = createProjectDescription;

                context.Projects.AddObject(dbProject);
                context.SaveChanges();
            }
        }

        public void UpdateUser(UserInfo userInfo)
        {
            using (var context = CreateContext())
            {
                var dbUser = new User();
                dbUser.Id = userInfo.Id;
                context.Users.Attach(dbUser);

                dbUser.Login = userInfo.Login;
                dbUser.Password = userInfo.Password;
                dbUser.RoleId = context.Roles.Where(it => it.Name == userInfo.Role).FirstOrDefault().Id;

                context.SaveChanges();
            }
        }

        public List<TaskInfo> GetAllTasks()
        {
            using (var context = CreateContext())
            {
                var tasks = context.Tasks.OrderBy(it => it.Id).ToArray();

                var result = TaskTranslator.ToListTaskInfo(tasks);
                return result;
            }
        }

        public List<ProjectInfo> GetAllProjects()
        {
            using (var context = CreateContext())
            {
                var projects = context.Projects.OrderBy(it => it.Id).ToArray();

                var result = ProjectTranslator.ToListProjectInfo(projects);
                return result;
            }
        }

        public List<UserInfo> GetAllUsers()
        {
            using (var context = CreateContext())
            {
                var users = context.Users.OrderBy(it => it.Id).ToArray();

                var result = UserTranslator.ToListUserInfo(users);
                return result;
            }
        }

        public void AddTaskToUser(int idTask, int idUser)
        {
            using (var context = CreateContext())
            {
                var task = context.Tasks.Where(it => it.Id == idTask).FirstOrDefault();

                task.IdUser = idUser;

                context.SaveChanges();
            }
        }

        public List<TaskInfo> GetAllTasksProjectForIteration(int idProject)
        {
            using (var context = CreateContext())
            {
                var tasks = context.Tasks.Where(it => it.IdProject == idProject && 
                                                      it.IdUser == null &&
                                                      it.NumberIteration == null);

                return TaskTranslator.ToListTaskInfo(tasks.ToArray());
            }
        }

        public List<TaskInfo> GetFreeTasks()
        {
            using (var context = CreateContext())
            {
                var tasks = context.Tasks.Where(it => it.IdUser == null && it.NumberIteration != null);

                return TaskTranslator.ToListTaskInfo(tasks.ToArray());
            }
        }

        public List<TaskInfo> GetWorkTasks(int idUser)
        {
            using (var context = CreateContext())
            {
                var tasks = context.Tasks.Where(it => it.IdUser == idUser && it.IsSolved == false);

                return TaskTranslator.ToListTaskInfo(tasks.ToArray());
            }
        }

        public void SetTaskSolved(int taskId)
        {
            using (var context = CreateContext())
            {
                var task = new Task();
                task.Id = taskId;

                context.Tasks.Attach(task);
                task.IsSolved = true;

                context.SaveChanges();
            }
        }

        public int UpdateIterationCounter(int idProject)
        {
            using (var context = CreateContext())
            {
                var project = context.Projects.Where(it => it.Id == idProject).FirstOrDefault();

                project.CountIteration++;

                context.SaveChanges();

                return project.CountIteration;
            }
        }

        public void SetTaskIteration(int idTask, int currentIterationNumber)
        {
            using (var context = CreateContext()) 
            {
                var task = new Task();
                task.Id = idTask;

                context.Tasks.Attach(task);
                task.NumberIteration = currentIterationNumber;

                context.SaveChanges();
            }
        }

        public int GetIterationCounterForProject(int idProject)
        {
            using (var context = CreateContext())
            {
                return context.Projects.Where(it => it.Id == idProject).FirstOrDefault().CountIteration;
            }
        }

        public List<TaskInfo> GetTasksInIteration(int idProject, int numberIteration)
        {
            using (var context = CreateContext())
            {
                var tasks = context.Tasks.Where(it => it.IdProject == idProject && 
                                                      it.NumberIteration == numberIteration);

                return TaskTranslator.ToListTaskInfo(tasks.ToArray());
            }
        }
    }
}
