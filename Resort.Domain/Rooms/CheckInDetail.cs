using Resort.Domain.RoomHistory;
using Resort.Domain.SharedKernel;

namespace Resort.Domain.Rooms;

public class CheckInDetail: AggregateRoot<Guid>
{
    private CheckInDetail()
    {
        
    }
    
    public Guid CustomerId { get; private set; }
    public Guid RoomId { get; private set; }
    public DateTime CheckInDate { get; private set; }

    public CheckInDetail(Guid customerId, Guid roomId, DateTime checkInDate)
    {
        CustomerId = customerId;
        RoomId = roomId;
        CheckInDate = checkInDate;
    }
}