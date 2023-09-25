using Resort.Domain.SharedKernel;

namespace Resort.Domain.RoomHistory;

public class CheckInOutLogs : AggregateRoot<Guid>
{
    private CheckInOutLogs()
    {

    }

    public string RoomNo { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime CheckInDate { get; private set; }
    public DateTime? CheckOutDate { get; private set; }

    public CheckInOutLogs(Guid id, string roomNo, Guid customerId, DateTime checkInDate,
        DateTime checkOutDate) : base(id)
    {
        RoomNo = roomNo;
        CustomerId = customerId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
    }

    public void CheckAvailability(Room room)
    {
        if (CheckOutDate == null)
        {
            room.SetRoomAvailability(false);
        }
    }

    public void SetGrandTotal(decimal grandTotal)
    {
        
    }
}