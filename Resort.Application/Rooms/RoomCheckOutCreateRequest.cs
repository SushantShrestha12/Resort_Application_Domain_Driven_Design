using MediatR;
using Resort.Application.Helpers;
using Resort.Domain;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class RoomCheckOutCreateRequest : IRequest<Room>
{
    public Guid RoomId { get; set; }
    public Guid BookingId { get; set; }
    public Guid CustomerId { get; set; }
}

public class RoomCheckOutCreateRequestHandler : IRequestHandler<RoomCheckOutCreateRequest, Room>
{
    private readonly ResortDbContext _context;

    public RoomCheckOutCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }

    public async Task<Room> Handle(RoomCheckOutCreateRequest request, CancellationToken cancellationToken)
    {
        var room = _context.Rooms.FirstOrDefault(x => x.RoomId == request.RoomId);
        var checkInOutLogs = _context.CheckInOutLogs
            .FirstOrDefault(x => x.CustomerId == request.CustomerId);
        
        var order = _context.Orders.FirstOrDefault(o => o.CustomerId == request.CustomerId);
        var booking = _context.Bookings.FirstOrDefault(o => o.Id == request.BookingId);
        
        if (room.Status == RoomStatusHelper.CheckedIn)
        {
            DateTime checkInDate = checkInOutLogs.CheckInDate;
            DateTime checkOutDate = DateTime.Today;

            TimeSpan stayDuration = checkOutDate - checkInDate;

            int totalStayDays = stayDuration.Days;

            decimal roomPrice = room.Rate.Amount;
            decimal RoomTotal = totalStayDays * roomPrice;

            decimal grandTotal = (RoomTotal + order.Total) - booking.Advance;
            
            checkInOutLogs.SetGrandTotal(grandTotal);
        }
        
        room.SetRoomStatus(RoomStatusHelper.CheckedOut);
        _context.SaveChanges();
        
        // if (booking.Advance > 0)
        // {
        //     room.SetRoomStatus(RoomStatusHelper.Confirmed);
        // }
        
        return room;
    }
}