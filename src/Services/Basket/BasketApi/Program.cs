

using BuildingBlocks.Exceptions.Handler;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCarter();
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(Program).Assembly);
    conf.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    conf.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(options => 
{
    options.Connection(builder.Configuration.GetConnectionString("Databases")!);
    options.Schema.For<ShopingCart>().Identity(x=>x.Username);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository,BasketRepository>();
builder.Services.Decorate<IBasketRepository,CachedBasketRepository>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis")!;
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Databases")!)
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapCarter();
app.UseExceptionHandler(options => {});
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();

