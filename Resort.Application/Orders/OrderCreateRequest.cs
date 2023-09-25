using MediatR;
using Resort.Application.Firms;
using Resort.Domain;
using Resort.Domain.Customers;
using Resort.Domain.Orders;
using Resort.Infrastructure;

namespace Resort.Application.Orders;

public class OrderCreateRequest: IRequest<Order>
{
    public Guid CustomerId { get; set; }
    public Guid FirmId { get; set; }
    public DateOnly Date { get; set; }
    public List<OrderLineItemCreateRequest> OrderLineItems { get; set; }

    public class OrderCreateRequestHandler : IRequestHandler<OrderCreateRequest, Order>
    {
        private readonly ResortDbContext _context;

        public OrderCreateRequestHandler(ResortDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(OrderCreateRequest request, CancellationToken cancellationToken)
        {
            Guid orderId = Guid.NewGuid();
            
            Order order = new Order(orderId, request.CustomerId, request.FirmId, request.Date);
            foreach (var i in request.OrderLineItems)
            {
                order.AddOrderLineItem(i.Item, i.Quantity, i.Currency, i.Amount);
            }
            
            order.CalculateTotal(order.OrderDetails);
            
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
            return order;
        }
        
    }
}