namespace Resort.UI.Contracts.Orders;

public class OrderCreate
{
    public Guid CustomerId { get; set; }
    public DateOnly Date { get; set; }
    public List<OrderLineItemCreate> OrderLineItems { get; set; }
    
}