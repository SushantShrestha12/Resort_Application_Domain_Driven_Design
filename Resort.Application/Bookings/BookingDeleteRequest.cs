using MediatR;
using Resort.Domain.Bookings;
using Resort.Domain.Customers;
using Resort.Infrastructure;

namespace Resort.Application.Bookings;

public class BookingDeleteRequest: IRequest<Booking>
{
    public Guid BookingId { get; set; }
}

public class BookingDeleteRequestHandler : IRequestHandler<BookingDeleteRequest, Booking>
{
    private readonly ResortDbContext _context;

    public BookingDeleteRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
        
    public async Task<Booking> Handle(BookingDeleteRequest request, CancellationToken cancellationToken)
    {
        Booking booking = await _context.Bookings.FindAsync(request.BookingId);

        if (booking == null)
        {
            return null;
        }

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync(cancellationToken);

        return booking;
    }
}