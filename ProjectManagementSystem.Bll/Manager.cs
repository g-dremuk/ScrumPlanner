using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Bll
{
    public class Manager : IManager
    {
        private int[][] profitMemorization;

        private int currentIterationNumber { get; set; }

        public IStorage Storage { get; set; }

        private List<TaskInfo> Tasks { get; set; }

        private TaskInfo[] AllTasksForIteration { get; set; }

        private readonly int durationTime = 80;

        public Manager(IStorage storage)
        {
            if (storage == null) throw new ArgumentNullException("storage");

            Storage = storage;
        }
        
        public void AddNewTaskToProject(int idProject, string name, string description, int profit, int duration)
        {
            Storage.AddTaskToProject(new TaskInfo(name, description, profit, duration, idProject));
        }

        public void CreateNewProject(string createProjectName, string createProjectDescription)
        {
            Storage.CreateProject(createProjectName, createProjectDescription);
        }

        public List<TaskInfo> GenerateIteration(int idProject)
        {
            currentIterationNumber = Storage.UpdateIterationCounter(idProject);
            AllTasksForIteration = Storage.GetAllTasksProjectForIteration(idProject).ToArray();

            var countTasksInProject = AllTasksForIteration.Count();
            profitMemorization = new int[countTasksInProject][];
            Tasks = new List<TaskInfo>();

            for (int i = 0; i < countTasksInProject; i++)
            {
                profitMemorization[i] = new int[durationTime + 1];
                for (int j = 0; j < profitMemorization[i].Length; j++)
                { profitMemorization[i][j] = -1; }
            }

            TasksOnDurationTime(countTasksInProject, durationTime);

            return Tasks;            
        }

        public void IterationProgress()
        {
            throw new NotImplementedException();
        }

        public void ProjectProgress()
        {
            throw new NotImplementedException();
        }    

        private int SearchProfit(int numberTasks, int durationTime)
        {
            numberTasks--;

            if (numberTasks < 0 || durationTime <= 0) return 0;
            if (profitMemorization[numberTasks][durationTime] != -1)
                return profitMemorization[numberTasks][durationTime];

            int withThisTask = 0;
            if ((durationTime - AllTasksForIteration[numberTasks].Duration) >= 0)
            {
                withThisTask = SearchProfit(numberTasks, durationTime - AllTasksForIteration[numberTasks].Duration) +
                                                AllTasksForIteration[numberTasks].Profit;
            }

            int withoutThisTask = SearchProfit(numberTasks, durationTime);

            profitMemorization[numberTasks][durationTime] = Math.Max(withThisTask, withoutThisTask);

            return withThisTask > withoutThisTask ? withThisTask : withoutThisTask;
        }

        private void TasksOnDurationTime(int numberTasks, int durationTime)
        {
            if (numberTasks != 0 && durationTime > 0)
            {
                numberTasks--;

                int withThisTask = 0;
                if ((durationTime - AllTasksForIteration[numberTasks].Duration) >= 0)
                {
                    withThisTask = SearchProfit(numberTasks, durationTime - AllTasksForIteration[numberTasks].Duration) + 
                                                    AllTasksForIteration[numberTasks].Profit;
                }

                var withoutThisTask = SearchProfit(numberTasks, durationTime);

                if (withThisTask > withoutThisTask)
                {
                    Storage.SetTaskIteration(AllTasksForIteration[numberTasks].Id, currentIterationNumber);

                    Tasks.Add(new TaskInfo(AllTasksForIteration[numberTasks].Name,
                                                 AllTasksForIteration[numberTasks].Description,
                                                 AllTasksForIteration[numberTasks].Profit,
                                                 AllTasksForIteration[numberTasks].Duration));
                    TasksOnDurationTime(numberTasks, durationTime - AllTasksForIteration[numberTasks].Duration);
                }
                else TasksOnDurationTime(numberTasks, durationTime);
            }
        }
    }
}
