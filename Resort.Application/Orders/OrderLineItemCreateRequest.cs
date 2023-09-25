using MediatR;

namespace Resort.Application.Orders;
public class OrderLineItemCreateRequest: IRequest
{
    public string Item { get;  set; }
    public int Quantity { get;  set; }
    public string Currency { get; set; }
    public decimal Amount { get; set; } 
}

