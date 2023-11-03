using Microsoft.EntityFrameworkCore;
using Resort.Infrastructure;

namespace Resort.UI.Contracts.Tokens;
public class AccessTokenExpireCheck
{
    private readonly ResortDbContext _context;
    private readonly ISession _session;
    // private readonly IHttpContextAccessor _httpContextAccessor;

    public AccessTokenExpireCheck(ResortDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _session = httpContextAccessor.HttpContext.Session;
        // _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> IsAccessTokenExpired()
    {
        var username = _session.GetString("Username");  //For swagger API
        // var username = _httpContextAccessor.HttpContext.Request.Headers["Username"].FirstOrDefault(); //To get the username from the header (Javascript)

        // if (username == null)
        // {
        //     username = _session.GetString("Username"); 
        // }
        
        var accessToken = await _context.AccessTokens
            .Where(token => token.Username == username)
            .FirstOrDefaultAsync();

        return accessToken?.AccExpires > DateTime.UtcNow;
    }
}