namespace ProjectManagementSystem.BllRequirements
{
    public interface ICurrentUserProvider
    {
        bool IsAdmin { get; }
        string Name { get; }
    }
}