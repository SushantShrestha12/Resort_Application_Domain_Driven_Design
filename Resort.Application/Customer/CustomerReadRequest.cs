using MediatR;
using Resort.Domain.Customers;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class CustomerReadRequest: IRequest<Customer>
{
    public Guid CustomerId { get; set; }
}

public class CustomerReadRequestHandler : IRequestHandler<CustomerReadRequest, Customer>
{
    private readonly ResortDbContext _context;

    public CustomerReadRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Customer> Handle(CustomerReadRequest request, CancellationToken cancellationToken)
    {
        Customer customer = await _context.Customers.FindAsync(request.CustomerId);

        if (customer == null)
        {
            return null;
        }

        return customer;
    }
}