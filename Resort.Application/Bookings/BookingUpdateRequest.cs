using MediatR;
using Resort.Domain.Bookings;
using Resort.Infrastructure;

namespace Resort.Application.Bookings;

public class BookingUpdateRequest: IRequest<Booking>
{
    public Guid BookingId { get; set; }
    public Guid CustomerId { get;  set; }
    public Guid FirmId { get;  set; }
    public int RoomId { get;  set; }
    public DateTime DateBooked { get; set; }
    public DateTime DateBookedFor { get; set; }
}

public class BookingUpdateRequestHandler : IRequestHandler<BookingUpdateRequest, Booking>
{
    private readonly ResortDbContext _context;

    public BookingUpdateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Booking> Handle(BookingUpdateRequest request, CancellationToken cancellationToken)
    {
        Booking booking = new Booking(request.BookingId, request.FirmId, request.RoomId, 
            request.CustomerId, request.DateBooked, request.DateBookedFor);

        if (booking == null)
        {
            return null;
        }
        
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync(cancellationToken);

        return booking;
    }
}