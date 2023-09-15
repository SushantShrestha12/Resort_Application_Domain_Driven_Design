using Resort.Domain.SharedKernel;

namespace Resort.Domain.Bookings;

public class Booking: AggregateRoot<Guid>
{
    private Booking()
    {
        
    }
    public Booking(Guid id, Guid firmId, Guid roomId, Guid customerId, DateTime dateBooked,
        DateTime dateBookedFor, decimal advance)
        :base(id)
    {
        FirmId = firmId;
        RoomId = roomId;
        CustomerId = customerId;
        DateBooked = dateBooked;
        DateBookedFor = dateBookedFor;
        Advance = advance;
    }
    
    public Guid FirmId { get; private set; }
    public Guid RoomId { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime? DateBooked { get; private set; }
    public DateTime DateBookedFor { get; private set; }
    public decimal Advance { get; private set; }
    public decimal GrandTotal { get; set; }
    
    public void UpdateBooking(DateTime dateBooked, DateTime dateBookedFor)
    {
        DateBooked = dateBooked;
        DateBookedFor = dateBookedFor;
    }
    
    
    // public void SetGrandTotal(decimal grandTotal)
    // {
    //     GrandTotal = grandTotal;
    // }

    //
    // public string? GetBookingStatus()
    // {
    //     string? status = null;
    //     if (DateBooked != null)
    //     {
    //           status = "Booked";
    //     }
    //     else if (Advance >= 0)
    //     {
    //           status = "Confirmed";
    //     }
    //     
    //     return status;
    // }

    // public string SetRoomStatus(string status)
    // {
    //     
    // }
}