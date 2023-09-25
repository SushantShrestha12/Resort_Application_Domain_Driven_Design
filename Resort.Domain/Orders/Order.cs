using Resort.Domain.SharedKernel;
namespace Resort.Domain.Orders;
public class Order : AggregateRoot<Guid>
{
    private Order()
    {
        Paid = false;
    }

    public DateOnly Date { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid FirmId { get; private set; }
    public decimal Total { get; private set; }
    public bool Paid { get; private set; }
    
    private readonly List<OrderLineItem> _orderDetails = new();
    public IReadOnlyCollection<OrderLineItem> OrderDetails => _orderDetails;
    
    public Order(Guid id, Guid customerId, Guid firmId, DateOnly date) 
        : base(id)
    {
        CustomerId = customerId;
        FirmId = firmId;
        Date = date;
        Paid = false;
    }

    public void AddOrderLineItem(string item, int quantity, string currency, decimal amount)
    {
        _orderDetails.Add(new OrderLineItem(item, quantity, new Rates(currency, amount)));
    }

    public void CalculateTotal(IReadOnlyCollection<OrderLineItem> orders)
    {
        Total = orders.Sum(x => x.Total);
    }
    
}