using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Application.Firms;
using Resort.Application.Orders;
using Resort.Infrastructure;
using Resort.UI.Contracts;

[ApiController]
[Route("[controller]")]
public class FirmsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ResortDbContext _context;
    
    public FirmsController(IMediator mediator, ResortDbContext context)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IResult> CreateFirm([FromBody] FirmCreate firm)
    {
        var command = new FirmCreateRequest
        {
            Name = firm.Name,
            AddressLine = firm.AddressLine,
            City = firm.City,
            ContactPerson = firm.ContactPerson,
            Email = firm.Email,
            MobileNumber = firm.MobileNumber,
            Municipality = firm.Municipality,
            Province = firm.Province,
            TelephoneNumber = firm.TelephoneNumber,
            WardNumber = firm.WardNumber,
            Website = firm.Website
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }

    [HttpDelete]
    [Route("Firm/{firmId}")]
    public async Task<IResult> DeleteFirm(Guid firmId, [FromBody] FirmDelete firm)
    {
        var command = new FirmDeleteRequest
        {
            FirmId = firmId,
        };

        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
    
    [HttpPut]
    [Route("Firm/{firmId}")]
    public async Task<IResult> UpdateFirm(Guid firmId, [FromBody] FirmUpdate firm)
    {
        var command = new FirmUpdateRequest
        {
            FirmId = firmId,
            AddressLine = firm.AddressLine,
            City = firm.City,
            ContactPerson = firm.ContactPerson,
            Email = firm.Email,
            MobileNumber = firm.MobileNumber,
            Municipality = firm.Municipality,
            Province = firm.Province,
            TelephoneNumber = firm.TelephoneNumber,
            WardNumber = firm.WardNumber,
            Website = firm.Website
        };
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }

    [HttpGet]
    [Route("Firm")]
    public async Task<IResult> ReadFirm(Guid firmId)
    {
        var result = await _mediator.Send(new GetAllFirmRequest());
        return Results.Ok(result);
    }
}