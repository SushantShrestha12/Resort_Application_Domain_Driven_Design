namespace Resort.UI.Contracts;

public class BookingUpdate
{
    public Guid CustomerId { get;  set; }
    public Guid FirmId { get;  set; }
    public int RoomId { get;  set; }
    public DateTime DateBooked { get; set; }
    public DateTime DateBookedFor { get; set; }
}