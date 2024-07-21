

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapCarter();

app.Run();

