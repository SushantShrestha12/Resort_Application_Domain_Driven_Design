using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Customers;
using Resort.Domain.LandingPages;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class GetAllLoginRequest : IRequest<List<SignUp>>
{
    
}

public class GetAllLoginRequestHandler : IRequestHandler<GetAllLoginRequest, List<SignUp>>
{
    private readonly  ResortDbContext _context;

    public GetAllLoginRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<SignUp>> Handle(GetAllLoginRequest request, CancellationToken cancellationToken)
    {
        return await _context.SignUps.ToListAsync();
    }
}