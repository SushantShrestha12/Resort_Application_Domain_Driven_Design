namespace Resort.UI.Contracts;

public class PaymentCreate
{
    public string Date { get;  set; }
    public string Price { get;  set; }
    public string Total { get;  set; }
    public string Discount { get;  set; }
    public string GrandTotal { get;  set; }
}

