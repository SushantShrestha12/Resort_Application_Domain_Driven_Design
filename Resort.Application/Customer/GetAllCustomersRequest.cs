using MediatR;
using Microsoft.EntityFrameworkCore;
using Resort.Domain.Customers;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class GetAllCustomersRequest : IRequest<List<Customer>>
{
    
}

public class GetAllCustomerRequestHandler : IRequestHandler<GetAllCustomersRequest, List<Customer>>
{
    private readonly  ResortDbContext _context;

    public GetAllCustomerRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Customer>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
    {
        return await _context.Customers.ToListAsync();
    }
}