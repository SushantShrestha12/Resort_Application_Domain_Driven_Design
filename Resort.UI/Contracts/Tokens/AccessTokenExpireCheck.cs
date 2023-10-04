using Microsoft.EntityFrameworkCore;
using Resort.Infrastructure;

namespace Resort.UI.Contracts.Tokens;
public class AccessTokenExpireCheck
{
    private readonly ResortDbContext _context;
    private readonly ISession _session;

    public AccessTokenExpireCheck(ResortDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _session = httpContextAccessor.HttpContext.Session; }

    public async Task<bool> IsAccessTokenExpired()
    {
        var username = _session.GetString("Username");

        var accessToken = await _context.AccessTokens
            .Where(token => token.Username == username)
            .FirstOrDefaultAsync();

        return accessToken?.AccExpires > DateTime.UtcNow;
    }
}