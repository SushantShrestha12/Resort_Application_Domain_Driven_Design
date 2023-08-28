using MediatR;
using Resort.Domain.Bookings;
using Resort.Infrastructure;

namespace Resort.Application.Bookings;

public class BookingReadRequest: IRequest<Booking>
{
    public Guid BookingId { get; set; }
}

public class BookingReadRequestHandler : IRequestHandler<BookingReadRequest, Booking>
{
    private readonly ResortDbContext _context;

    public BookingReadRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Booking> Handle(BookingReadRequest request, CancellationToken cancellationToken)
    {
        Booking booking = await _context.Bookings.FindAsync(request.BookingId);
        
        if (booking == null)
        {
            return null;
        }
        
        return booking;
    }
}