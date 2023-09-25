using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using Resort.Domain;
using Resort.Domain.Firms;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class GetRoomStatusCreateRequest: IRequest<Room?>
{
    public Guid RoomId { get; set; }
}

public class GetRoomStatusCreateRequestHandler : IRequestHandler<GetRoomStatusCreateRequest, Room?>
{
    private readonly ResortDbContext _context;

    public GetRoomStatusCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Room?> Handle(GetRoomStatusCreateRequest request, CancellationToken cancellationToken)
    {
        var room = await _context.Rooms
            .Where(r => r.RoomId == request.RoomId)
            .FirstOrDefaultAsync();
        
        return room;
    }
}