using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.RoomHistory;
using Resort.UI.Contracts;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckInOutLogsController: ControllerBase
{
    private readonly IMediator _mediator;

    public CheckInOutLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("checkInOutLogs")]
    public async Task<IResult> CreateCheckInOutLogs([FromBody] CheckInOutLogsCreate check)
    {
        var command = new CheckInOutLogsCreateRequest()
        {
            RoomNo = check.RoomNo,
            CustomerId = check.CustomerId,
            CheckInDate = check.CheckInDate,
            CheckOutDate = check.CheckOutDate
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
    
    [HttpDelete]
    [Route("checkInOutLogs/{historyId}")]
    public async Task<IResult> DeleteCheckInOutLogs(Guid historyId)
    {
        var command = new CheckInOutLogsDeleteRequest()
        {
            HistoryId = historyId
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
}