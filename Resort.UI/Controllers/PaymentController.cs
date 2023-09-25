using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Firms;
using Resort.UI.Contracts;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController: ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Payment/{firmId}/{customerId}")]
    public async Task<IResult> CreatePayment(Guid firmId, Guid customerId,
        [FromBody] PaymentCreate payment)
    {
        var command = new PaymentCreateRequest()
        {
            FirmId = firmId,
            CustomerId = customerId,
            Date = payment.Date,
            Price = payment.Price,
            Total = payment.Total,
            Discount = payment.Discount,
            GrandTotal = payment.GrandTotal
        };
        
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
    
    [HttpGet]
    [Route("Payment/{paymentId}")]
    public async Task<IResult> ReadPayment(Guid paymentId)
    {
        var command = new PaymentReadRequest()
        {
            PaymentId = paymentId
        };

        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
}