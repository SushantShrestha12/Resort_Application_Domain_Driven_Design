using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Customers;
using Resort.Domain.SharedKernel;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class CustomerUpdateRequest: IRequest<Customer>
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string Municipality { get; set; }
    public string AddressLine { get; set; }
    public string WardNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}

public class CustomerUpdateRequestHandler : IRequestHandler<CustomerUpdateRequest, Customer>
{
    private readonly ResortDbContext _context;

    public CustomerUpdateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Customer> Handle(CustomerUpdateRequest request, CancellationToken cancellationToken)
    {
        var customerToUpdate = await _context.Customers.FirstOrDefaultAsync(c => c.Id == request.CustomerId);
        if (customerToUpdate == null)
            return null;
        
        Address address = new Address(request.Province, request.City, request.Municipality,
            request.AddressLine, request.WardNumber);
        Contact contact = new Contact(request.MobileNumber, request.Email);

        customerToUpdate.UpdateAddress(address);
        customerToUpdate.UpdateContactDetail(contact);
        
        _context.Customers.Update(customerToUpdate);
        await _context.SaveChangesAsync(cancellationToken);

        return customerToUpdate;
    }
}