using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resort.Domain.Customers;
using Resort.Domain.SharedKernel;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class CustomerCreateRequest: IRequest<Customer>
{
    public string Name { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string Municipality { get; set; }
    public string AddressLine { get; set; }
    public string WardNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}

public class CustomerCreateRequestHandler : IRequestHandler<CustomerCreateRequest, Customer>
{
    private readonly ResortDbContext _context;

    public CustomerCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Customer> Handle(CustomerCreateRequest request, CancellationToken cancellationToken)
    {
        Address address = new Address(request.Province, request.City, request.Municipality, request.AddressLine,
            request.WardNumber);

        Contact contact = new Contact(request.MobileNumber, request.Email);
        
        Guid customerId = Guid.NewGuid();
        Customer customer = new Customer(customerId, request.Name, address, contact);

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return customer;
    }
}