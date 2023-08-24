namespace Resort.UI.Contracts;

public class OrderLineItemCreate
{
    public string Item { get;  set; }
    public int Quantity { get;  set; }
    public string Currency { get; set; }
    public decimal Amount { get; set; }
}