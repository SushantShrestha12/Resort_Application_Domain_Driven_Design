using MediatR;
using Resort.Domain.Firms;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class PaymentCreateRequest: IRequest<Payment>
{
    public Guid FirmId { get; set; }
    public Guid CustomerId { get; set; }
    public string Date { get; set; }
    public string Price { get;  set; }
    public string Total { get;  set; }
    public string Discount { get;  set; }
    public string GrandTotal { get;  set; }
}

public class PaymentCreateRequestHandler : IRequestHandler<PaymentCreateRequest, Payment>
{
    private readonly ResortDbContext _context;

    public PaymentCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }


    public async Task<Payment> Handle(PaymentCreateRequest request, CancellationToken cancellationToken)
    {
        Guid paymentId = Guid.NewGuid();
        Payment payment = new Payment(paymentId, request.Date, request.Price,
            request.Total, request.Discount, request.GrandTotal);

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync(cancellationToken);

        return payment;
    }
}
    