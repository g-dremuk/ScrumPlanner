using ProjectManagementSystem.Bll;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Tests.Mocks
{
    public class FakeTaskChecker : ITaskAdditionalChecks
    {
        private readonly bool _doIncrease;

        public FakeTaskChecker(bool doIncrease)
        {
            _doIncrease = doIncrease;
        }

        public bool ShouldTaskViewCounterBeIncreased(TaskInfo task)
        {
            return _doIncrease;
        }
    }
}