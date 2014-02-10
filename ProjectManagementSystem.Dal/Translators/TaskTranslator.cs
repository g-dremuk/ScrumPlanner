using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ProjectManagementSystem.Dal.DatabaseModels;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Dal.Translators
{
    internal class TaskTranslator
    {
        public static Task FromTaskInfo(TaskInfo taskInfo, bool withId = true)
        {
            var task = new Task();
            CopyTaskInfoToTask(taskInfo, task);
            if (withId) task.Id = taskInfo.Id;
            return task;
        }

        public static TaskInfo[] ToTaskInfo(Task[] tasks)
        {
            var result = tasks.Select(ToTaskInfo).ToArray();
            return result;
        }

        public static List<TaskInfo> ToListTaskInfo(Task[] tasks)
        {
            var result = tasks.Select(ToTaskInfo).ToList();
            return result;
        }

        public static TaskInfo ToTaskInfo(Task task)
        {
            var result = new TaskInfo(task.Id, task.Name, task.Description, task.Profit, task.Duration, task.IdProject);
            return result;
        }

        public static void CopyTaskInfoToTask(TaskInfo source, Task target)
        {
            target.Name = source.Name;
            target.Profit = source.Profit;
            target.Description = source.Description;
            target.Duration = source.Duration;
            target.IdProject = source.IdProject;
            if (source.IdUser > 0) target.IdUser = source.IdUser;
        }
    }
}
