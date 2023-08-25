using MediatR;
using Resort.Domain.Firms;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class FirmDeleteRequest: IRequest<Firm>
{
    public Guid FirmId { get; set; }
}

public class FirmDeleteRequestHandler : IRequestHandler<FirmDeleteRequest, Firm>
{
    private readonly ResortDbContext _context;

    public FirmDeleteRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Firm> Handle(FirmDeleteRequest request, CancellationToken cancellationToken)
    {
        
        Firm firm = await _context.Firms.FindAsync(request.FirmId);
        
        if (firm == null)
        {
            return null;
        }

        _context.Firms.Remove(firm);
        await _context.SaveChangesAsync(cancellationToken);

        return firm;
    }
}