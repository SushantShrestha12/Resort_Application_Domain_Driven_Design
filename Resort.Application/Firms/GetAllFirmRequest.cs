using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Firms;
using Resort.Infrastructure;

namespace Resort.Application.Orders;

public class GetAllFirmRequest: IRequest<List<Firm>>
{
    
}

public class GetAllFirmRequestHandler : IRequestHandler<GetAllFirmRequest, List<Firm>>
{
    private readonly  ResortDbContext _context;

    public GetAllFirmRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Firm>> Handle(GetAllFirmRequest request, CancellationToken cancellationToken)
    {
        return await _context.Firms.ToListAsync();
    }
}