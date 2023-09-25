using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Bookings;
using Resort.Application.Firms;
using Resort.UI.Contracts;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController: ControllerBase
{
    private readonly IMediator _mediator;

    public BookingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Booking/{firmId}/{roomId}/{customerId}")]
    public async Task<IResult> CreateBooking(Guid firmId, int roomId, Guid customerId,
        [FromBody] BookingCreate booking)
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
    
    [HttpDelete]
    [Route("booking/{bookingId}")]
    public async Task<IResult> DeleteBooking(Guid bookingId, [FromBody] CustomerDelete customer)
    {
        var command = new BookingDeleteRequest()
        {
            BookingId = bookingId
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
    
    [HttpPut]
    [Route("booking/{bookingId}")]
    public async Task<IResult> UpdateBooking(Guid bookingId, [FromBody] BookingUpdate booking)
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
    
    [HttpGet]
    [Route("Booking/{bookingId}")]
    public async Task<IResult> ReadBooking(Guid bookingId)
    {
        var command = new BookingReadRequest()
        {
            BookingId = bookingId
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
}