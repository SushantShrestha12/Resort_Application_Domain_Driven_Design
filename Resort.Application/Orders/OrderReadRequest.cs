using MediatR;
using Resort.Domain.Orders;
using Resort.Infrastructure;

namespace Resort.Application.Orders;

public class OrderReadRequest : IRequest<Order>
{
    public Guid OrderId { get; set; }
}

public class OrderReadRequestHandler : IRequestHandler<OrderReadRequest, Order>
{
    private readonly ResortDbContext _context;

    public OrderReadRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Order> Handle(OrderReadRequest request, CancellationToken cancellationToken)
    {
        Order order = await _context.Orders.FindAsync(request.OrderId);

        if (order == null)
        {
            return null;
        }

        return order;
    }
}
