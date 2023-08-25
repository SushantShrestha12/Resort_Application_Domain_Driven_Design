using MediatR;
using Resort.Domain.Firms;
using Resort.Domain.SharedKernel;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class FirmReadRequest : IRequest<Firm>
{
    public Guid FirmId { get; set; }
    public string Name { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string Municipality { get; set; }
    public string AddressLine { get; set; }
    public string WardNumber { get; set; }
    
    public string ContactPerson { get; set; }
    public string MobileNumber { get; set; }
    public string TelephoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
}

public class FirmReadRequestHandler: IRequestHandler<FirmReadRequest, Firm>
{
    private readonly ResortDbContext _context;

    public FirmReadRequestHandler(ResortDbContext context)
    {
        _context = context;
    }

    public async Task<Firm> Handle(FirmReadRequest request, CancellationToken cancellationToken)
    {
        Firm firm = await _context.Firms.FindAsync(request.FirmId);
        
        if (firm == null)
        {
            return null;
        }
        
        return firm;
    }
}