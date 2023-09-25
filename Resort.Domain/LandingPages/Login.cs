using Resort.Domain.SharedKernel;

namespace Resort.Domain.LandingPages;

public class Login: AggregateRoot<Guid>
{
    private Login()
    {
        
    }
    public string Username { get; private set; }
    public string Password { get; private set; }

    public Login(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
}