using MediatR;
using Resort.Domain;
using Resort.Domain.RoomHistory;
using Resort.Infrastructure;

namespace Resort.Application.RoomHistory;

public class CheckInOutLogsCreateRequest: IRequest<CheckInOutLogs>
{
    public string RoomNo { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}

public class CheckInOutLogsHandler : IRequestHandler<CheckInOutLogsCreateRequest, CheckInOutLogs>
{
    private readonly ResortDbContext _context;

    public CheckInOutLogsHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<CheckInOutLogs> Handle(CheckInOutLogsCreateRequest request, CancellationToken cancellationToken)
    {
        Guid historyId = Guid.NewGuid();

        //var rooms = _context.Firms.Select(f => f.Rooms).ToList();
        //rooms.Where(r => r. == 1);
        
        // Guid customerId = _context.Customers.Where(c => c.Id == request.CustomerId)
        //     .Select(c => c.Id)
        //     .FirstOrDefault();

        var booking = _context.Bookings.Select(b => b.FirmId);
        
        CheckInOutLogs checkInOutLogs = new CheckInOutLogs(historyId, request.RoomNo,
            request.CustomerId, request.CheckInDate, request.CheckOutDate);

        _context.CheckInOutLogs.Add(checkInOutLogs);
        await _context.SaveChangesAsync(cancellationToken);
        
        return checkInOutLogs;
    }
}
