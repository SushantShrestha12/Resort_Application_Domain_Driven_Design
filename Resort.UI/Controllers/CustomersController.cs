using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Firms;
using Resort.UI.Contracts;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController: ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Customers")]
    public async Task<IResult> CreateCustomer(Guid firmId, [FromBody] CustomerCreate customer)
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
    
    [HttpDelete]
    [Route("Customers/{customerId}")]
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
    [Route("Customers/{customerId}")]
    public async Task<IResult> UpdateCustomer(Guid customerId, [FromBody] CustomerUpdate customer)
    {
        var command = new CustomerUpdateRequest()
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

    
}