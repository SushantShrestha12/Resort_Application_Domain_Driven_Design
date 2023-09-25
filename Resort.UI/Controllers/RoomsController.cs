using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Firms;
using Resort.UI.Contracts;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController: ControllerBase
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Firm/{firmId}/room")]
    public async Task<IResult> CreateRoom(Guid firmId, [FromBody] RoomCreate room)
    {
        var command = new RoomCreateRequest()
        {
            FirmId = firmId,
            Number = room.Number,
            RoomType = room.RoomType,
            AC = room.AC,
            Wifi = room.Wifi,
            Bed = room.Bed,
            TV = room.TV,
            Currency = room.Currency,
            Amount = room.Amount ?? 0,
            Availability = room.Availability,
        };
        
        await _mediator.Send(command);
        return Results.Ok();
    }
    
    
}