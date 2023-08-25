using MediatR;
using Resort.Domain.Firms;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class PaymentUpdateRequest: IRequest<Payment>
{
    public Guid PaymentId { get; set; }
    public string Date { get; set; }
    public string Price { get;  set; }
    public string Total { get;  set; }
    public string Discount { get;  set; }
    public string GrandTotal { get;  set; }
}

public class PaymentUpdateRequestHandler : IRequestHandler<PaymentUpdateRequest, Payment>
{
    private readonly ResortDbContext _context;

    public PaymentUpdateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }


    public async Task<Payment> Handle(PaymentUpdateRequest request, CancellationToken cancellationToken)
    {
        Payment payment = new Payment(request.PaymentId, request.Date, request.Price,
            request.Total, request.Discount, request.GrandTotal);

        _context.Payments.Update(payment);
        await _context.SaveChangesAsync(cancellationToken);

        return payment;
    }
}