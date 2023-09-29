using MediatR;
using Resort.Domain.Token;
using Resort.Infrastructure;

namespace Resort.Application.Tokens;

public class AccessTokenCreateRequest : IRequest<AccessToken>
{
    public string Username { get; set; }
    public string AccToken { get; set; }
    public DateTime AccExpires { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshExpires { get; set; }
}

public class AccessTokenCreateRequestHandler : IRequestHandler<AccessTokenCreateRequest, AccessToken>
{
    private readonly ResortDbContext _context;

    public AccessTokenCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }

    public async Task<AccessToken> Handle(AccessTokenCreateRequest request, CancellationToken cancellationToken)
    {
        AccessToken accessToken = new AccessToken(request.Username, request.AccToken, request.AccExpires,
            request.RefreshToken, request.RefreshExpires);

        _context.AccessTokens.Add(accessToken);
        await _context.SaveChangesAsync(cancellationToken);

        return accessToken;
    }
}