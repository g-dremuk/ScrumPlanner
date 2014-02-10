using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.BllInterfaces
{
    /*
     *  Planning:
     *  2) CreateNewProject (createProjectName)
     *  3) AddTask (to Project)
     *  Iteration:
     *  4) GenerateIteration - здесь решение задачи на перебор
     *  Display: 
     *  5) IterationProgress
     *  6) ProjectProgress      - в двух последних просто отображаем что выполнено, 
     *                              что выполняется, что можно будет выполнить ???
    */
    public interface IManager
    {
        /// <summary>
        /// Add new task.
        /// </summary>
        /// <param name="task"></param>
        void AddNewTaskToProject(int idProject, string name, string description, int profit, int duration);
        
        //  TaskInfo GetById(int id);

        void CreateNewProject(string createProjectName, string createProjectDescription);

        List<TaskInfo> GenerateIteration(int idProject);
    }
}
