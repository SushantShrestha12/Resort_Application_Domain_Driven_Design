namespace Resort.Domain.Orders;

public record OrderLineItem
{
    private OrderLineItem()
    {
        
    }
    public string Item { get; private set; }
    public int Quantity { get; private set; }
    public Rates Price { get; private set; }
    public decimal Total { get; private set; }
    public OrderLineItem(string item, int quantity, Rates price)
    {
        Item = item;
        Quantity = quantity;
        Price = price;
        Total = Quantity * Price.Amount;
    }
}