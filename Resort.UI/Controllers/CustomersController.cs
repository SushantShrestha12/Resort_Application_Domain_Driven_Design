using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Firms;
using Resort.UI.Contracts;
using Resort.UI.Contracts.Tokens;

namespace Resort.UI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ISession _session;
    private readonly AccessTokenExpireCheck _accessTokenExpireCheck;


    public CustomersController(IMediator mediator, IHttpContextAccessor httpContextAccessor,
        AccessTokenExpireCheck accessTokenExpireCheck)
    {
        _mediator = mediator;
        _session = httpContextAccessor.HttpContext.Session;
        _accessTokenExpireCheck = accessTokenExpireCheck;
    }
    

    [HttpPost]
    public async Task<IResult> CreateCustomer([FromBody] CustomerCreate customer)
    {
        var username = _session.GetString("Username");

        if (username == null)
        {
            throw new Exception("You have to login first.");
        }

        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (tokenNotExpired)
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
        var username = _session.GetString("Username");
        if (username == null)
        {
            throw new Exception("You have to login first.");
        }

        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (tokenNotExpired)
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
        return Results.BadRequest("Token Expired");

    }

    [HttpGet]
    public async Task<IResult> ReadCustomer()
    {
        // var username = _session.GetString("Username");

        // if (username == null)
        // {
        //     throw new Exception("You have to login first.");
        // }
        
        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();
        
        if (tokenNotExpired)
        {
            var result = await _mediator.Send(new GetAllCustomersRequest());
            return Results.Ok(result);
        }
        return Results.BadRequest("Token Expired");
    }
}