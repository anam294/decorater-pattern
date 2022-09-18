using DesignPatternDecorator.Abstraction;
using DesignPatternDecorator.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IPlayersService, PlayersService>();

if (Convert.ToBoolean(builder.Configuration["EnableCaching"]))
{
    builder.Services.Decorate<IPlayersService, PlayersServiceCachingDecorator>();
}

if (Convert.ToBoolean(builder.Configuration["EnableLogging"]))
{
    builder.Services.Decorate<IPlayersService, PlayersServiceLoggingDecorator>();
}

var app = builder.Build();

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

