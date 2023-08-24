using Resort.Domain;

namespace Resort.UI.Contracts;

public class RoomCreate
{
    public string? Number { get; set; }
    public RoomTypes  RoomType { get; set; }
    public bool AC { get;  set; }
    public bool Bed { get;  set; }
    public bool Wifi { get;  set; }
    public bool TV { get;  set; }
    public string? Currency { get; set; }
    public decimal? Amount { get; set; }
    public bool Availability { get; set; }
}