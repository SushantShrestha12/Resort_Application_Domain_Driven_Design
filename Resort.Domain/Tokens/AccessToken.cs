using System.Runtime.InteropServices.JavaScript;
using Resort.Domain.SharedKernel;

namespace Resort.Domain.Token;

public class AccessToken: AggregateRoot<Guid>
{
    private AccessToken()
    {
        
    }

    public string Username { get; private set; }
    public string AccToken { get;  private set; }
    public DateTime AccExpires { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime RefreshExpires { get; private set; }
    
    public AccessToken(string username, string accToken, DateTime accExpires, string refreshToken, DateTime refreshExpires)
    {
        Username = username;
        AccToken = accToken;
        AccExpires = accExpires;
        RefreshToken = refreshToken;
        RefreshExpires = refreshExpires;
    }
    
}