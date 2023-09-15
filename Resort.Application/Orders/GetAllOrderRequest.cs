using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Orders;
using Resort.Infrastructure;

namespace Resort.Application.Orders;

public class GetAllOrderRequest: IRequest<List<Order>>
{
    
}

public class GetAllOrderRequestHandler : IRequestHandler<GetAllOrderRequest, List<Order>>
{
    private readonly  ResortDbContext _context;

    public GetAllOrderRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Order>> Handle(GetAllOrderRequest request, CancellationToken cancellationToken)
    {
        return await _context.Orders.ToListAsync();
    }
}