using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Resort.Application.Firms;
using Resort.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("ResortContext");
builder.Services.AddDbContext<ResortDbContext>(options => options.UseMySql(cs, ServerVersion.AutoDetect(cs)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(FirmCreateRequestHandler).Assembly));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Resort API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter into field the word 'Bearer' following by space and JWT",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Access Token"]))
        };
    });

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
    option.AddPolicy("User", policy => policy.RequireClaim("User"));
});

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

app.UseCors();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();