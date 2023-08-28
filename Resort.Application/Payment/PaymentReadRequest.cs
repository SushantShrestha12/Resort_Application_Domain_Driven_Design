using MediatR;
using Resort.Domain.Firms;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class PaymentReadRequest: IRequest<Payment>
{
    public Guid PaymentId { get; set; }
}

public class PaymentReadRequestHandler : IRequestHandler<PaymentReadRequest, Payment>
{
    private readonly ResortDbContext _context;

    public PaymentReadRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Payment> Handle(PaymentReadRequest request, CancellationToken cancellationToken)
    {
        Payment payment = await _context.Payments.FindAsync(request.PaymentId);

        if (payment == null)
        {
            return null;
        }

        return payment;
    }
}