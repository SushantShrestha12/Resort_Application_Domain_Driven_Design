using Resort.Domain.Orders;

namespace Resort.UI.Contracts;

public class OrderCreate
{
    public Guid CustomerId { get; set; }
    public DateOnly Date { get; set; }
    public List<OrderLineItemCreate> OrderLineItems { get; set; }
    
}