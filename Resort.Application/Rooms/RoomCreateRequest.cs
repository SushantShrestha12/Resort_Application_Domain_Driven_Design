using MediatR;
using Resort.Domain;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class RoomCreateRequest: IRequest
{
    public Guid RoomId { get; set; }
    public Guid FirmId { get;  set; }
    public string Number { get; set; }
    public RoomTypes  RoomType { get; set; }
    public bool AC { get;  set; }
    public bool Bed { get;  set; }
    public bool Wifi { get;  set; }
    public bool TV { get;  set; }
    public string Currency { get; set; }
    public decimal Amount { get; set; }
    public bool Availability { get; set; }
    public string? Status { get; set; }
}

public class RoomCreateRequestHandler: IRequestHandler<RoomCreateRequest>
{
    private readonly ResortDbContext _context;

    public RoomCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RoomCreateRequest request, CancellationToken cancellationToken)
    {
        
        Features features = new Features(request.AC, request.Bed, request.Wifi, request.TV);
        Rates rates = new Rates(request.Currency, request.Amount);
        
        var firm = _context.Firms.FirstOrDefault(f => f.Id == request.FirmId);

        if (firm == null)
        {
            throw new ArgumentException("The firm is not available / Invalid Firm Id");
        }
        
        firm.AddRoom(request.RoomId, request.Number, request.RoomType, features, rates);

        await _context.SaveChangesAsync(cancellationToken);
    }
}