using MediatR;
using Resort.Domain.Orders;
using Resort.Infrastructure;

namespace Resort.Application.Orders;

public class OrderDeleteRequest: IRequest<Order>
{
    public Guid OrderId { get; set; }
}

public class OrderDeleteRequestHandler : IRequestHandler<OrderDeleteRequest, Order>
{
    private readonly ResortDbContext _context;

    public OrderDeleteRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Order> Handle(OrderDeleteRequest request, CancellationToken cancellationToken)
    {
        Order order = await _context.Orders.FindAsync(request.OrderId);

        if (order == null)
        {
            return null;
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);

        return order;
    }
}