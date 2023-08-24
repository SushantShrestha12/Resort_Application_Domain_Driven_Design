using MediatR;
using Resort.Domain.Bookings;
using Resort.Infrastructure;

namespace Resort.Application.Bookings;

public class BookingCreateRequest: IRequest<Booking>
{
    public Guid CustomerId { get;  set; }
    public Guid FirmId { get;  set; }
    public int RoomId { get;  set; }
    public DateTime DateBooked { get; set; }
    public DateTime DateBookedFor { get; set; }
}

public class BookingCreateRequestHandler : IRequestHandler<BookingCreateRequest, Booking>
{
    private readonly ResortDbContext _context;

    public BookingCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Booking> Handle(BookingCreateRequest request, CancellationToken cancellationToken)
    {
        Guid bookingId = Guid.NewGuid();
        Booking booking = new Booking(bookingId, request.FirmId, request.RoomId, 
            request.CustomerId, request.DateBooked, request.DateBookedFor);

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync(cancellationToken);

        return booking;
    }
}