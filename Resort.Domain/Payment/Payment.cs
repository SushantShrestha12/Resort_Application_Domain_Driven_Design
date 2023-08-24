using Resort.Domain.SharedKernel;

namespace Resort.Domain.Firms;

public class Payment : AggregateRoot<Guid>
{
    private Payment()
    {
        
    }
    
    public string Date { get; private set; }
    public string RoomStayed { get; private set; }
    public string TotalStay { get; private set; }
    public string Price { get; private set; }
    public string Total { get; private set; }
    public string Discount { get; private set; }
    public string GrandTotal { get; private set; }

    public Payment(Guid id,string date, string roomStayed, string totalStay, string price,
        string total, string discount, string grandTotal)
    {
        Date = date;
        RoomStayed = roomStayed;
        TotalStay = totalStay;
        Price = price;
        Total = total;
        Discount = discount;
        GrandTotal = grandTotal;
    }
}