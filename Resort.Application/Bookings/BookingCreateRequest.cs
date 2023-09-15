using MediatR;
using Resort.Application.Helpers;
using Resort.Domain.Bookings;
using Resort.Infrastructure;

namespace Resort.Application.Bookings;

public class BookingCreateRequest : IRequest<Booking>
{
    public Guid CustomerId { get; set; }
    public Guid FirmId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime DateBooked { get; set; }
    public DateTime DateBookedFor { get; set; }
    public decimal Advance { get; set; }
}

public class BookingCreateRequestHandler : IRequestHandler<BookingCreateRequest, Booking>
{
    private readonly ResortDbContext _context;
    private readonly IMediator _mediator;

    public BookingCreateRequestHandler(ResortDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Booking> Handle(BookingCreateRequest request, CancellationToken cancellationToken)
    {
        var firm = _context.Firms.FirstOrDefault(f => f.Id == request.FirmId);
        var room = _context.Rooms.FirstOrDefault(x => x.RoomId == request.RoomId);
        var customer = _context.Customers.FirstOrDefault(c => c.Id == request.CustomerId);
        
        if (firm == null)
        {
            throw new ArgumentException("The firm is not available. / Invalid Firm ID.");
        }
        
        if (room == null)
        {
            throw new ArgumentException("The room is not available. / Invalid Room ID.");
        }
        
        if (customer == null)
        {
            throw new ArgumentException("Invalid Customer Id");
        }

        // check null case
        // TODO: check for nullable case
        
        if (room.Status == RoomStatusHelper.Confirmed || room.Status == RoomStatusHelper.Booked)
        {
            throw new ArgumentException("The room is already booked.");
        }
        
        room.SetRoomStatus(RoomStatusHelper.Booked);
        _context.SaveChanges();
        
        Guid bookingId = Guid.NewGuid();
        Booking booking = new Booking(bookingId, request.FirmId, request.RoomId,
            request.CustomerId, request.DateBooked, request.DateBookedFor, request.Advance);

        if (booking.Advance > 0)
        {
            room.SetRoomStatus(RoomStatusHelper.Confirmed);
            _context.SaveChanges();
        }

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync(cancellationToken);

        return booking;
    }
}