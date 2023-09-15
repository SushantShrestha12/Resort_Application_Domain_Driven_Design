using Resort.Domain.SharedKernel;

namespace Resort.Domain.RoomHistory;

public class CheckOutDetail: AggregateRoot<Guid>
{
    private CheckOutDetail()
    {
        
    }

    public Guid CustomerId { get; private set; }
    public DateTime Date { get; private set; }
    public string Particulars { get; private set; }
    public Rates Rate { get; private set; }
    public string Unit { get; private set; }
    public decimal Total { get; private set; }
    public decimal GrandTotal { get; private set; }

    public CheckOutDetail(Guid customerId, DateTime date, string particulars, 
        Rates rate, string unit, decimal total, decimal grandTotal)
    {
        CustomerId = customerId;
        Date = date;
        Particulars = particulars;
        Rate = rate;
        Unit = unit;
        Total = total;
        GrandTotal = grandTotal;
    }
}