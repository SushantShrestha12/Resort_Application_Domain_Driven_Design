using MediatR;
using Resort.Domain.Firms;
using Resort.Domain.Rooms;
using Resort.Infrastructure;

namespace Resort.Application.Rooms;

public class CheckInDetailCreateRequest: IRequest<CheckInDetail>
{
    public Guid CustomerId { get;  set; }
    public Guid RoomId { get;  set; }
    public DateTime CheckInDate { get;  set; }
}


public class CheckInDetailsCreateRequestHandler : IRequestHandler<CheckInDetailCreateRequest, CheckInDetail>
{
    private readonly ResortDbContext _context;

    public CheckInDetailsCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<CheckInDetail> Handle(CheckInDetailCreateRequest request, CancellationToken cancellationToken)
    {
        var room = _context.Rooms.FirstOrDefault(x => x.RoomId == request.RoomId);
        var customer = _context.Customers.FirstOrDefault(c => c.Id == request.CustomerId);

        if (room == null)
        {
            throw new ArgumentException("The room is not available. / Invalid Room Id.");
        }

        if (customer == null)
        {
            throw new ArgumentException("Invalid Customer Id.");
        }
        
        CheckInDetail checkInDetail = new CheckInDetail(request.CustomerId,request.RoomId,
            request.CheckInDate);

        _context.CheckInDetails.Add(checkInDetail);
        await _context.SaveChangesAsync(cancellationToken);
        
        return checkInDetail;
    }
}