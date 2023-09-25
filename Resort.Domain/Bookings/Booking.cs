using Resort.Domain.Customers;
using Resort.Domain.SharedKernel;

namespace Resort.Domain.Bookings;

public class Booking: AggregateRoot<Guid>
{
    private Booking()
    {
        
    }
    public Booking(Guid id, Guid firmId, int roomId, Guid customerId, DateTime dateBooked, DateTime dateBookedFor)
        :base(id)
    {
        FirmId = firmId;
        RoomId = roomId;
        CustomerId = customerId;
        DateBooked = dateBooked;
        DateBookedFor = dateBookedFor;
    }
    
    public Guid FirmId { get; private set; }
    public int RoomId { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime DateBooked { get; private set; }
    public DateTime DateBookedFor { get; private set; }
    public decimal Advance { get; set; }
    
    public void UpdateBooking(DateTime dateBooked, DateTime dateBookedFor)
    {
        DateBooked = dateBooked;
        DateBookedFor = dateBookedFor;
    }
     
    
}