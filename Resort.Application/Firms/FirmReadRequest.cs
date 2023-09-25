using MediatR;
using Resort.Domain.Firms;
using Resort.Domain.SharedKernel;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class FirmReadRequest : IRequest<Firm>
{
    public Guid FirmId { get; set; }
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