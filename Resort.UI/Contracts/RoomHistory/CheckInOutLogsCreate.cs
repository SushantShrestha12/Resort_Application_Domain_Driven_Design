namespace Resort.UI.Contracts.RoomHistory;

public class CheckInOutLogsCreate
{
    public string RoomNo { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}