namespace Resort.UI.Contracts.Payments;

public class PaymentCreate
{
    public DateTime Date { get;  set; }
    public decimal Price { get;  set; }
    public decimal Total { get;  set; }
    public decimal Discount { get;  set; }
    public decimal GrandTotal { get;  set; }
}

