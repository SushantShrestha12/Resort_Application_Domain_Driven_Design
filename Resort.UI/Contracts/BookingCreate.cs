namespace Resort.UI.Contracts;

public sealed class BookingCreate
{
    public DateTime DateBooked { get; set; }
    public DateTime DateBookedFor { get; set; }
}