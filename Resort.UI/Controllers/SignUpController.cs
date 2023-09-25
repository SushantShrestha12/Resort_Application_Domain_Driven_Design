using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.LandingPages;
using Resort.UI.Contracts.LandingPages;

namespace Resort.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class SignUpController : ControllerBase
{
    private readonly IMediator _mediator;

    public SignUpController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IResult> CreateSignUp([FromBody] SignUpCreate signUp)
    {
        var command = new SignUpCreateRequest
        {
            Username = signUp.Username,
            PhoneNumber = signUp.PhoneNumber,
            Email = signUp.Email,
            Password = signUp.Password,
            ConfirmPassword = signUp.ConfirmPassword
        };

        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
}