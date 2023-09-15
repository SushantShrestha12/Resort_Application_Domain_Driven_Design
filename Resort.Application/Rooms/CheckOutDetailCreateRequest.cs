using MediatR;
using Resort.Domain;
using Resort.Domain.RoomHistory;
using Resort.Infrastructure;

namespace Resort.Application.RoomHistory;

public class CheckOutDetailCreateRequest: IRequest<CheckOutDetail>
{
    public Guid CustomerId { get; set; }
    public DateTime Date { get; set; }
    public string Particulars { get; set; }
    public Rates Rate { get; set; }
    public string Unit { get; set; }
    public decimal Total { get; set; }
    public decimal GrandTotal { get; set; }
}

public class CheckOutDetailsCreateRequestHandler : IRequestHandler<CheckOutDetailCreateRequest, CheckOutDetail>
{
    private readonly ResortDbContext _context;

    public CheckOutDetailsCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<CheckOutDetail> Handle(CheckOutDetailCreateRequest request, CancellationToken cancellationToken)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == request.CustomerId);

        if (customer == null)
        {
            throw new ArgumentException("Invalid Customer Id.");
        }
        
        Guid customerId = new Guid();
        CheckOutDetail checkOutDetail = new CheckOutDetail(customerId, request.Date,request.Particulars, 
            request.Rate, request.Unit, request.Total, request.GrandTotal);

        _context.CheckOutDetails.Add(checkOutDetail);
        await _context.SaveChangesAsync(cancellationToken);
        
        return checkOutDetail;
    }
}