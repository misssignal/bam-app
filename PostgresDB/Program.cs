using Microsoft.Extensions.Configuration;
using PostgresDB.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using PostgresDB.Controllers;
using Microsoft.Extensions.Options;
using System.Data;
using PostgresDB;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/food", async(MyDbContext dbContext) =>
{
    var foodItems = await dbContext.sample_table_food.ToListAsync(); 
    return foodItems;
})
.WithName("GetFood")
.WithOpenApi();

app.MapGet("/food/{id}", async (int id, MyDbContext dbContext) => 
{ 
    var foodItem = await dbContext.sample_table_food.FindAsync(id); 
    if (foodItem == null) 
    { 
        return Results.NotFound(); 
    } 
    return Results.Ok(foodItem);
})
.WithName("GetFoodbyId")
.WithOpenApi();

app.MapGet("/foodTable", async (MyDbContext dbContext) =>
{
    var foodDataTable = await DataTableHelper.GetFoodDataTableAsync(dbContext);
    return Results.Ok(foodDataTable);
})
.WithName("GetFoodTable")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public record Food(int id, string type, string channelName1, string channelName2, string channelName3, string to, string pos, string ml, string fl1, string fl2, string fl3, string dim, string dir, string filt)
{

}
