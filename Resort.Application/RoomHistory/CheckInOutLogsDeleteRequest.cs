using MediatR;
using Resort.Domain.RoomHistory;
using Resort.Infrastructure;

namespace Resort.Application.RoomHistory;

public class CheckInOutLogsDeleteRequest: IRequest<CheckInOutLogs>
{
    public Guid HistoryId { get; set; }
}

public class CheckInOutLogsDeleteRequestHandler : IRequestHandler<CheckInOutLogsDeleteRequest, CheckInOutLogs>
{
    private readonly ResortDbContext _context;

    public CheckInOutLogsDeleteRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<CheckInOutLogs> Handle(CheckInOutLogsDeleteRequest request, CancellationToken cancellationToken)
    {
        CheckInOutLogs checkInOutLogs = await _context.CheckInOutLogs.FindAsync(request.HistoryId);

        if (checkInOutLogs == null)
        {
            return null;
        }

        _context.CheckInOutLogs.Remove(checkInOutLogs);
        await _context.SaveChangesAsync(cancellationToken);

        return checkInOutLogs;
    }
}