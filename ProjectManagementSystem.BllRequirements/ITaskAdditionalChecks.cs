using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.BllRequirements
{
    public interface ITaskAdditionalChecks
    {
        bool ShouldTaskViewCounterBeIncreased(TaskInfo task);
    }
}