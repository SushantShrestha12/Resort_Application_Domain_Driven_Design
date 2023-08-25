using MediatR;
using Resort.Domain.Customers;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class CustomerDeleteRequest: IRequest<Customer>
{
    public Guid CustomerId { get; set; }
}

public class CustomerDeleteRequestHandler : IRequestHandler<CustomerDeleteRequest, Customer>
{
    private readonly ResortDbContext _context;

    public CustomerDeleteRequestHandler(ResortDbContext context)
    {
        _context = context;
    }

    
    public async Task<Customer> Handle(CustomerDeleteRequest request, CancellationToken cancellationToken)
    {
        Customer customer = await _context.Customers.FindAsync(request.CustomerId);
        
        if (customer == null)
        {
            return null;
        }
        
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync(cancellationToken);
           
        return customer;
    }
}