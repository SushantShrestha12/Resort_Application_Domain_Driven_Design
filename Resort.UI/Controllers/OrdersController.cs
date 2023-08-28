using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Orders;
using Resort.UI.Contracts;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController: ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("orders")]
    public async Task<IResult> CreateOrders([FromBody] OrderCreate order)
    {
        List<OrderLineItemCreateRequest> orderLineItems = new List<OrderLineItemCreateRequest>();


        orderLineItems = order.OrderLineItems.Select(o => new OrderLineItemCreateRequest()
        {
            Amount = o.Amount,
            Quantity = o.Quantity,
            Currency = o.Currency,
            Item = o.Item
        }).ToList();


        var command = new OrderCreateRequest()
        {
            CustomerId = order.CustomerId,
            Date = order.Date,
            OrderLineItems = orderLineItems
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
    
    [HttpDelete]
    [Route("orders/{orderId}")]
    public async Task<IResult> DeleteOrders(Guid orderId, [FromBody] OrderDelete order)
    {
        var command = new OrderDeleteRequest()
        {
            OrderId = orderId
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
    
    [HttpGet]
    [Route("Order/{orderId}")]
    public async Task<IResult> ReadOrder(Guid orderId)
    {
        var command = new OrderReadRequest
        {
            OrderId = orderId
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
}