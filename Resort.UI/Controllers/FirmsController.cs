using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Resort.Application.Firms;
using Resort.Application.Orders;
using Resort.Infrastructure;
using Resort.UI.Contracts;
using Resort.UI.Contracts.Tokens;

[Authorize]
[ApiController]
[Route("[controller]")]
public class FirmsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ResortDbContext _context;
    private readonly AccessTokenExpireCheck _accessTokenExpireCheck;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FirmsController(IMediator mediator, ResortDbContext context,
        AccessTokenExpireCheck accessTokenExpireCheck, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _mediator = mediator;
        _accessTokenExpireCheck = accessTokenExpireCheck;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public async Task<IResult> CreateFirm([FromBody] FirmCreate firm)
    {
        var username = _httpContextAccessor.HttpContext.Request.Headers["Username"].FirstOrDefault(); //To get the username from the header (Javascript)

        if (username == null)
        {
            throw new Exception("You have to login first.");
        }

        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();
        if (!tokenNotExpired) return Results.BadRequest("Token Expired");
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

    private bool IsValidUser(string username, string password)
    {
        var user = _context.SignUps.Any(u => u.Username == username);
        var pass = _context.SignUps.Any(u => u.Password == password);

        return user && pass;
    }

    [HttpGet]
    public async Task<IResult> ReadFirm()
    {
        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();
        if (!tokenNotExpired) return Results.BadRequest("Token Expired");
        var result = await _mediator.Send(new GetAllFirmRequest());
        return Results.Ok(result);
    }
}