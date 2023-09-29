using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Token;
using Resort.Infrastructure;

namespace Resort.Application.Orders;

public class GetAllAccessTokenRequest: IRequest<List<AccessToken>>
{
    
}

public class GetAllAccessTokenRequestHandler : IRequestHandler<GetAllAccessTokenRequest, List<AccessToken>>
{
    private readonly  ResortDbContext _context;

    public GetAllAccessTokenRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<AccessToken>> Handle(GetAllAccessTokenRequest request, CancellationToken cancellationToken)
    {
        return await _context.AccessTokens.ToListAsync();
    }
}