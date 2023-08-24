using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resort.Application.Firms;
using Resort.Application.Orders;
using Resort.Application.Bookings;
using Resort.Application.RoomHistory;
using Resort.Infrastructure;
using Resort.UI.Contracts;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("ResortContext");
builder.Services.AddDbContext<ResortDbContext>(options => options.UseMySql(cs, ServerVersion.AutoDetect(cs)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(FirmCreateRequestHandler).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/firms", async (IMediator mediator, [FromBody] FirmCreate firm) =>
{
    var command = new FirmCreateRequest
    {
        Name = firm.Name,
        AddressLine = firm.AddressLine,
        City = firm.City,
        ContactPerson = firm.ContactPerson,
        Email = firm.Email,
        MobileNumber = firm.MobileNumber,
        Municipality = firm.Municipality,
        Province = firm.Province,
        TelephoneNumber = firm.TelephoneNumber,
        WardNumber = firm.WardNumber,
        Website = firm.Website
    };
    
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapDelete("/firms", async (IMediator mediator, Guid firmId,
    [FromBody] FirmDelete firm) =>
{
    var command = new FirmDeleteRequest()
    {
        FirmId = firmId
    };
    
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapPost("/firms/{firmId}/room", async (IMediator mediator, Guid firmId, [FromBody] RoomCreate room) =>
{
    var command = new RoomCreateRequest()
    {
        FirmId = firmId,
        Number = room.Number,
        RoomType = room.RoomType,
        AC = room.AC,
        Wifi = room.Wifi,
        Bed = room.Bed,
        TV = room.TV,
        Currency = room.Currency,
        Amount = room.Amount ?? 0,
        Availability = room.Availability,
    };
    
    await mediator.Send(command);
    return Results.Ok();
});

app.MapPost("/firms/menu", async (IMediator mediator, Guid firmId, [FromBody] MenuCreate menu) =>
{
    var command = new MenuCreateRequest()
    {
        FirmId = firmId,
        FoodName = menu.FoodName,
        Currency = menu.Currency,
        Amount = menu.Amount,
        Quantity = menu.Quantity,
        NonVeg = menu.NonVeg,
    };

    await mediator.Send(command);
    return Results.Ok();
});

app.MapPost("/customers", async (IMediator mediator, [FromBody] CustomerCreate customer) =>
{
    var command = new CustomerCreateRequest()
    {
        Name = customer.Name,
        Province = customer.Province,
        City = customer.City,
        Municipality = customer.Municipality,
        AddressLine = customer.AddressLine,
        WardNumber = customer.WardNumber,
        MobileNumber = customer.MobileNumber,
        Email = customer.Email
    };
    
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapPost("/bookings/{firmId}/{roomId}/{customerId}", async (IMediator mediator, 
    Guid firmId, int roomId, Guid customerId, [FromBody] BookingCreate booking) =>
{
    var command = new BookingCreateRequest()
    {
        FirmId = firmId,
        RoomId = roomId,
        CustomerId = customerId,
        DateBooked = booking.DateBooked,
        DateBookedFor = booking.DateBookedFor
    };
    
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapPost("/payment/{firmId}/{customerId}", async (IMediator mediator,
    Guid firmId, Guid customerId, 
    [FromBody] PaymentCreate payment) =>
{
    var command = new PaymentCreateRequest()
    {
        Date = payment.Date,
        Price = payment.Price,
        Total = payment.Total,
        Discount = payment.Discount,
        GrandTotal = payment.GrandTotal
    };
    
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapPost("/orders", async (IMediator mediator,
    [FromBody] OrderCreate order) =>
{
    List<OrderLineItemCreateRequest> orderLineItems = new List<OrderLineItemCreateRequest>();

    
        orderLineItems = order.OrderLineItems.Select(o => new OrderLineItemCreateRequest()
        {
            Amount = o.Amount,
            Quantity = o.Quantity,
            Currency = o.Currency,
            Item = o.Item
        }).ToList();
    

    var command = new OrderCreateRequest()
    {
        CustomerId = order.CustomerId,
        Date = order.Date,
        OrderLineItems = orderLineItems
    };
    
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.MapPost("/checkInOutLogs", async (IMediator mediator, 
    [FromBody] CheckInOutLogsCreate check) =>
{
    var command = new CheckInOutLogsCreateRequest()
    {
        RoomNo = check.RoomNo,
        CustomerId = check.CustomerId,
        CheckInDate = check.CheckInDate,
        CheckOutDate = check.CheckOutDate
    };
    
    var result = await mediator.Send(command);
    return Results.Ok(result);
});

app.Run();