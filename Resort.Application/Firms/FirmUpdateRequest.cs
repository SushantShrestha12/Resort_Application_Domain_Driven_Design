using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Firms;
using Resort.Domain.SharedKernel;
using Resort.Infrastructure;
using Contact = Resort.Domain.Firms.Contact;

namespace Resort.Application.Firms;

public class FirmUpdateRequest: IRequest<Firm>
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

public class FirmUpdateRequestHandler : IRequestHandler<FirmUpdateRequest, Firm>
{
    private readonly ResortDbContext _context;

    public FirmUpdateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Firm> Handle(FirmUpdateRequest request, CancellationToken cancellationToken)
    {
        var firmToUpdate = await _context.Firms.FirstOrDefaultAsync(f => f.Id == request.FirmId);
        if (firmToUpdate == null)
            return null;
        
        Address address = new Address(request.Province, request.City, request.Municipality, request.AddressLine,
            request.WardNumber);
        Contact contact = new Contact(request.ContactPerson, request.MobileNumber, request.TelephoneNumber,
            request.Email, request.Website);
        
        firmToUpdate.UpdateAddress(address);
        firmToUpdate.UpdateContactDetail(contact);

        _context.Firms.Update(firmToUpdate);
        await _context.SaveChangesAsync(cancellationToken);

        return firmToUpdate;
    }
}