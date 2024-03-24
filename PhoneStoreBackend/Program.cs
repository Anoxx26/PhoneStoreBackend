using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using PhoneStoreBackend.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PhoneStoreBackend;
using PhoneStoreBackend.Repositories;
using PhoneStoreBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,

            ValidIssuer = builder.Configuration.GetSection("AuthOptions")["ISSUER"],

            ValidateAudience = true,

            ValidAudience = builder.Configuration.GetSection("AuthOptions")["AUDIENCE"],

            ValidateLifetime = true,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AuthOptions")["KEY"] ?? "Aboba")),

            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<OrderRepository>();
builder.Services.AddTransient<OrderDetailsRepository>();

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
