using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Bookings;
using Resort.Infrastructure;

namespace Resort.Application.Bookings;

public class BookingUpdateRequest: IRequest<Booking>
{
    public Guid BookingId { get; set; }
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
        var bookingToUpdate = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == request.BookingId);
        if (bookingToUpdate == null)
            return null;
        
       // Booking booking = new Booking(request.BookingId, request.FirmId, request.RoomId, 
          //  request.CustomerId, request.DateBooked, request.DateBookedFor);
          
          bookingToUpdate.UpdateBooking(request.DateBooked, request.DateBookedFor);
   
        _context.Bookings.Update(bookingToUpdate);
        await _context.SaveChangesAsync(cancellationToken);

        return bookingToUpdate;
    }
}