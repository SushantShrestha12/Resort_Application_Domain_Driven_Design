using Resort.Domain.Bookings;
using Resort.Domain.SharedKernel;

namespace Resort.Domain.Firms;

public class Payment : AggregateRoot<Guid>
{
    private Payment()
    {
        
    }
    
    public DateTime Date { get; private set; }
    public decimal Price { get; private set; }
    public decimal Total { get; private set; }
    public decimal Discount { get; private set; }
    public decimal GrandTotal { get; private set; }

    public Payment(Guid id,DateTime date, Decimal price,
        Decimal total, Decimal discount, decimal grandTotal) :base(id)
    {
        Date = date;
        Price = price;
        Total = total;
        Discount = discount;
        GrandTotal = grandTotal;
    }
    // public string SetStatus()
    // {
    //     Booking booking = null;
    //     string status = booking.SetPaymentStatus(null);
    //     return status;
    // }
}