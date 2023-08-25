using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Firms;
using Resort.UI.Contracts;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController: ControllerBase
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Firm/{firmId}/menu")]
    public async Task<IResult> CreateMenu(Guid firmId, [FromBody] MenuCreate menu)
    {
        var command = new MenuCreateRequest()
        {
            FirmId = firmId,
            FoodName = menu.FoodName,
            Currency = menu.Currency,
            Amount = menu.Amount,
            Quantity = menu.Quantity,
            NonVeg = menu.NonVeg,
        };
        
        await _mediator.Send(command);
        return Results.Ok();
    }
    
    
}