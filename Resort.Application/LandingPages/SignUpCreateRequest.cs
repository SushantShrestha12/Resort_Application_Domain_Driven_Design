using MediatR;
using Resort.Domain.LandingPages;
using Resort.Infrastructure;

namespace Resort.Application.LandingPages;

public class SignUpCreateRequest : IRequest<SignUp>
{
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class SignUpCreateRequestHandler : IRequestHandler<SignUpCreateRequest, SignUp>
{
    private readonly ResortDbContext _context;

    public SignUpCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }

    public async Task<SignUp> Handle(SignUpCreateRequest request, CancellationToken cancellationToken)
    {
        var signUp = new SignUp(Guid.NewGuid(), request.Username, request.PhoneNumber,
            request.Email, request.Password, request.ConfirmPassword);
        _context.SignUps.Add(signUp);
        await _context.SaveChangesAsync(cancellationToken);
        return signUp;
    }
}