using MediatR;
using Resort.Domain;
using Resort.Domain.Firms;
using Resort.Infrastructure;

namespace Resort.Application.Firms;

public class MenuCreateRequest: IRequest
{
    public Guid FirmId { get; set; }
    public string FoodName { get;  set; }
    public string Currency { get;  set; }
    public decimal Amount { get;  set; }
    public int Quantity { get;  set; }
    public bool NonVeg { get;  set; }
}

public class MenuCreateRequestHandler: IRequestHandler<MenuCreateRequest>
{
        
    private readonly ResortDbContext _context;

    public MenuCreateRequestHandler(ResortDbContext context)
    {
        _context = context;
    }
        
    public async Task Handle(MenuCreateRequest request, CancellationToken cancellationToken)
    {
        Rates price = new Rates(request.Currency, request.Amount);
        FoodType foodType = new FoodType(request.NonVeg);
        
        var firm = _context.Firms.FirstOrDefault(f => f.Id == request.FirmId);
        firm.AddFoodMenu(request.FoodName, price, request.Quantity, foodType);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}