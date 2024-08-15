using System.Text.Json;
using WebApplication_IT_Academy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var weatherForecast = new WeatherForecast
{
    Date = new DateOnly(2024, 8, 15),
    TemperatureC = 27,
    Summary = "Hot"
};

Console.WriteLine(JsonSerializer.Serialize(weatherForecast));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
