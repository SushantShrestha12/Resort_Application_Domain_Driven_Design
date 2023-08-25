// using MediatR;
// using Resort.Application.Firms;
// using Resort.Domain;
// using Resort.Domain.Customers;
// using Resort.Domain.Orders;
// using Resort.Infrastructure;
//
// namespace Resort.Application.Orders;
//
// public class OrderUpdateRequest: IRequest<Order>
// {
//     public Guid OrderId { get; set; }
//     public Guid CustomerId { get; set; }
//     public Guid FirmId { get; set; }
//     public DateOnly Date { get; set; }
//     public List<OrderLineItemUpdateRequest> OrderLineItems { get; set; }
//
//     public class OrderUpdateRequestHandler : IRequestHandler<OrderUpdateRequest, Order>
//     {
//         private readonly ResortDbContext _context;
//
//         public OrderUpdateRequestHandler(ResortDbContext context)
//         {
//             _context = context;
//         }
//
//         public async Task<Order> Handle(OrderUpdateRequest request, CancellationToken cancellationToken)
//         {
//             Order order = new Order(request.OrderId, request.CustomerId, request.FirmId, request.Date);
//             foreach (var i in request.OrderLineItems)
//             {
//                 order.AddOrderLineItem(i.Item, i.Quantity, i.Currency, i.Amount);
//             }
//
//             if (order == null)
//             {
//                 return null;
//             }
//             
//             //order.CalculateTotal(order.OrderDetails);
//             
//             _context.Orders.Update(order);
//             await _context.SaveChangesAsync(cancellationToken);
//             return order;
//         }
//         
//     }
// }