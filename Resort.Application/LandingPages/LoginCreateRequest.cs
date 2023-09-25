using MediatR;
using Resort.Domain.LandingPages;
using Resort.Infrastructure;

namespace Resort.Application.LandingPages;

public class LoginCreateRequest: IRequest<Login>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginCreateRequestHandler: IRequestHandler<LoginCreateRequest, Login>
{
    private readonly ResortDbContext _context;
    public LoginCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Login> Handle(LoginCreateRequest request, CancellationToken cancellationToken)
    {
        var login = new Login(request.Username, request.Password);
        _context.Logins.Add(login);
        await _context.SaveChangesAsync(cancellationToken);
        return login;
    }
}
