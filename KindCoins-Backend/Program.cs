using System.Net.Sockets;
using KindCoins_Backend.KindCoins.Domain.Repositories;
using KindCoins_Backend.KindCoins.Domain.Services;
using KindCoins_Backend.KindCoins.Mapping;
using KindCoins_Backend.KindCoins.Persistence.Repositories;
using KindCoins_Backend.KindCoins.Services;
using KindCoins_Backend.Shared.Persistence.Contexts;
using KindCoins_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);
//Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Dependency Injection Configuration

//User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//Campaign
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<ICampaignService, CampaignService>();

//TypeOfDonation
builder.Services.AddScoped<ITypeOfDonationRepository, TypeOfDonationRepository>();
builder.Services.AddScoped<ITypeOfDonationService, TypeOfDonationService>();

//SuscriptionPlan
builder.Services.AddScoped<ISuscriptionPlanRepository, SuscriptionPlanRepository>();
builder.Services.AddScoped<ISuscriptionPlanService, SuscriptionPlanService>();

//BankAccount
builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();

//Country
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

//Department    
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

//Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();