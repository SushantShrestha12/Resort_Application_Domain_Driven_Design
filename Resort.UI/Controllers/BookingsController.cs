using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Bookings;
using Resort.Application.Firms;
using Resort.UI.Contracts;
using Resort.UI.Contracts.Tokens;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ISession _session;
    private readonly AccessTokenExpireCheck _accessTokenExpireCheck;

    public BookingsController(IMediator mediator, ISession session, IHttpContextAccessor httpContextAccessor, AccessTokenExpireCheck accessTokenExpireCheck)
    {
        _mediator = mediator;
        _session = httpContextAccessor.HttpContext.Session;
        _accessTokenExpireCheck = accessTokenExpireCheck;
    }

    [HttpPost]
    [Route("Booking/{firmId}/{roomId}/{customerId}")]
    public async Task<IResult> CreateBooking(Guid firmId, int roomId, Guid customerId,
        [FromBody] BookingCreate booking)
    {
        var username = _session.GetString("Username");
        if (username == null)
        {
            throw new Exception("You have to login first.");
        }

        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (tokenNotExpired)
        {
            var command = new BookingCreateRequest()
            {
                FirmId = firmId,
                RoomId = roomId,
                CustomerId = customerId,
                DateBooked = booking.DateBooked,
                DateBookedFor = booking.DateBookedFor
            };

            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
        return Results.BadRequest("Token expired.");
    }
    
    [HttpDelete]
    [Route("booking/{bookingId}")]
    public async Task<IResult> DeleteBooking(Guid bookingId, [FromBody] CustomerDelete customer)
    {
        var username = _session.GetString("Username");
        if (username == null)
        {
            throw new Exception("You have to login first.");
        }

        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (tokenNotExpired)
        {
            var command = new BookingDeleteRequest()
            {
                BookingId = bookingId
            };

            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
        return Results.BadRequest("Token expired.");
    }
    
    [HttpPut]
    [Route("booking/{bookingId}")]
    public async Task<IResult> UpdateBooking(Guid bookingId, [FromBody] BookingUpdate booking)
    {
        var username = _session.GetString("Username");
        if (username == null)
        {
            throw new Exception("You have to login first.");
        }

        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (tokenNotExpired)
        {
            var command = new BookingUpdateRequest()
            {
                BookingId = bookingId,
                DateBooked = booking.DateBooked,
                DateBookedFor = booking.DateBookedFor
            };

            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
        return Results.BadRequest("Token expired.");
    }
    
    [HttpGet]
    [Route("Booking/{bookingId}")]
    public async Task<IResult> ReadBooking(Guid bookingId)
    {
        var username = _session.GetString("Username");
        if (username == null)
        {
            throw new Exception("You have to login first.");
        }

        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (tokenNotExpired)
        {
            var command = new BookingReadRequest()
            {
                BookingId = bookingId
            };

            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }
        return Results.BadRequest("Token expired.");
    }
}