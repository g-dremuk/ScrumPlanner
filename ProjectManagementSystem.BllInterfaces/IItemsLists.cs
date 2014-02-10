using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.BllInterfaces
{
    //Всякие массивы:
    //  1). Список всех пользователей
    //  2). Список всех задач
    //  3). Список всех проектов

    public interface IItemsLists
    {
        //классы Task и Project должны быть свои
        List<TaskInfo> GetAllTasks();
        List<ProjectInfo> GetAllProjects();
        List<UserInfo> GetAllUsers();

        List<TaskInfo> GetTasksForWork();
    }
}
