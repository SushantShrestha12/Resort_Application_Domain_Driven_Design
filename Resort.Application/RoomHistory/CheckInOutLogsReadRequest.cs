using MediatR;
using Resort.Domain.RoomHistory;
using Resort.Infrastructure;

namespace Resort.Application.RoomHistory;

public class CheckInOutLogsReadRequest: IRequest<CheckInOutLogs>
{
    public Guid HistoryId { get; set; } 
}

public class CheckInOutLogsReadRequestHandler : IRequestHandler<CheckInOutLogsReadRequest, CheckInOutLogs>
{
    private readonly ResortDbContext _context;

    public CheckInOutLogsReadRequestHandler(ResortDbContext context)
    {
        _context = context;
    }

    
    public async Task<CheckInOutLogs> Handle(CheckInOutLogsReadRequest request, CancellationToken cancellationToken)
    {
        CheckInOutLogs checkInOutLogs = await _context.CheckInOutLogs.FindAsync(request.HistoryId);

        if (checkInOutLogs == null)
        {
            return null;
        }

        return checkInOutLogs;
    }
}