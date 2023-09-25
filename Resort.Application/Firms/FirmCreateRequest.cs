using MediatR;
using Resort.Domain.Firms;
using Resort.Domain.SharedKernel;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class FirmCreateRequest : IRequest<Firm>
{
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

public class FirmCreateRequestHandler: IRequestHandler<FirmCreateRequest, Firm>
{
    private readonly ResortDbContext _context;

    public FirmCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }

    public async Task<Firm> Handle(FirmCreateRequest request, CancellationToken cancellationToken)
    {
        Address address = new Address(request.Province, request.City, request.Municipality, request.AddressLine,
            request.WardNumber);

        Contact contact = new Contact(request.ContactPerson, request.MobileNumber, request.TelephoneNumber,
            request.Email, request.Website);

        Guid firmId = Guid.NewGuid();
        Firm firm = new Firm(firmId, request.Name, address, contact);

        _context.Firms.Add(firm);
        await _context.SaveChangesAsync(cancellationToken);
        
        return firm;
    }
}