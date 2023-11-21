namespace Resort.Domain.SharedKernel
{
    public interface ISessionService
    {
        string GetUsername();
        void SetUsername(string username);
    }
}