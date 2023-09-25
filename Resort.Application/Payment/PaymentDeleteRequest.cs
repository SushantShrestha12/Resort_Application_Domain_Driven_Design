using MediatR;
using Resort.Domain.Firms;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class PaymentDeleteRequest: IRequest<Payment>
{
    public Guid PaymentId { get; set; }
}

public class PaymentDeleteRequestHandler : IRequestHandler<PaymentDeleteRequest, Payment>
{
    private readonly ResortDbContext _context;

    public PaymentDeleteRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
    
    public async Task<Payment> Handle(PaymentDeleteRequest request, CancellationToken cancellationToken)
    {
        Payment payment = await _context.Payments.FindAsync(request.PaymentId);

        if (payment == null)
        {
            return null;
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync(cancellationToken);

        return payment;
    }
}