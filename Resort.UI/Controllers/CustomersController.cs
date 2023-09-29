using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resort.Application.Firms;
using Resort.Infrastructure;
using Resort.UI.Contracts;

namespace Resort.UI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ResortDbContext _context;
    private readonly ISession _session;

    public CustomersController(IMediator mediator, ResortDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _mediator = mediator;
        _session = httpContextAccessor.HttpContext.Session;
    }

    [HttpPost]
    public async Task<IResult> CreateCustomer([FromBody] CustomerCreate customer)
    {
        var username = _session.GetString("Username");

        if (username == null)
        {
            throw new Exception("You have to login first.");
        }

        var accessToken = await _context.AccessTokens
            .Where(token => token.Username == username)
            .FirstOrDefaultAsync();

        if (accessToken?.AccExpires > DateTime.Now)
        {
            var command = new CustomerCreateRequest()
            {
                Name = customer.Name,
                Province = customer.Province,
                City = customer.City,
                Municipality = customer.Municipality,
                AddressLine = customer.AddressLine,
                WardNumber = customer.WardNumber,
                MobileNumber = customer.MobileNumber,
                Email = customer.Email
            };

            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }

        return Results.BadRequest("Token Expired");
    }

    [HttpDelete]
    public async Task<IResult> DeleteCustomer(Guid customerId, [FromBody] CustomerDelete customer)
    {
        var command = new CustomerDeleteRequest()
        {
            CustomerId = customerId
        };

        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }

    [HttpPut]
    public async Task<IResult> UpdateCustomer(Guid customerId, [FromBody] CustomerUpdate customer)
    {
        var command = new CustomerUpdateRequest
        {
            CustomerId = customerId,
            Name = customer.Name,
            Province = customer.Province,
            City = customer.City,
            Municipality = customer.Municipality,
            AddressLine = customer.AddressLine,
            WardNumber = customer.WardNumber,
            MobileNumber = customer.MobileNumber,
            Email = customer.Email
        };

        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }

    [HttpGet]
    public async Task<IResult> ReadCustomer()
    {
        var result = await _mediator.Send(new GetAllCustomersRequest());
        return Results.Ok(result);
    }
}