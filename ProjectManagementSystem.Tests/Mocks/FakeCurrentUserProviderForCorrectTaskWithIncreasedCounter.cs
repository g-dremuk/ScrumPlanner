using ProjectManagementSystem.BllRequirements;

namespace ProjectManagementSystem.Tests.Mocks
{
    public class FakeCurrentUserProviderForCorrectTaskWithIncreasedCounter : ICurrentUserProvider
    {
        public FakeCurrentUserProviderForCorrectTaskWithIncreasedCounter(bool isAdmin, string name)
        {
            IsAdmin = isAdmin;
            Name = name;
        }

        public bool IsAdmin { get; private set; }
        public string Name { get; private set; }
    }
}