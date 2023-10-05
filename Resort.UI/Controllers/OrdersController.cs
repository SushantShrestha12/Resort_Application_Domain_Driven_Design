using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Orders;
using Resort.UI.Contracts;
using Resort.UI.Contracts.Tokens;

namespace Resort.UI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly AccessTokenExpireCheck _accessTokenExpireCheck;

    public OrdersController(IMediator mediator, AccessTokenExpireCheck accessTokenExpireCheck)
    {
        _mediator = mediator;
        _accessTokenExpireCheck = accessTokenExpireCheck;
    }

    [HttpPost]
    public async Task<IResult> CreateOrders([FromBody] OrderCreate order)
    {
        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();
        if (!tokenNotExpired) return Results.BadRequest("Token Expired");

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
    public async Task<IResult> ReadOrder()
    {
        var tokenNotExpired = await _accessTokenExpireCheck.IsAccessTokenExpired();

        if (!tokenNotExpired) return Results.BadRequest("Token Expired");

        var result = await _mediator.Send(new GetAllOrderRequest());
        return Results.Ok(result);
    }
}