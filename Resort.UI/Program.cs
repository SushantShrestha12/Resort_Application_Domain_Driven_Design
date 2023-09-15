using Microsoft.EntityFrameworkCore;
using Resort.Application.Firms;
using Resort.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("ResortContext");
builder.Services.AddDbContext<ResortDbContext>(options => options.UseMySql(cs, ServerVersion.AutoDetect(cs)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(FirmCreateRequestHandler).Assembly));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();
app.UseCors(
    options =>
    {
        options.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();