using Microsoft.EntityFrameworkCore;
using Services.AuctionService.Data;
using Services.Ecommerce.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcommerceDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

app.MapGet("/Products", (EcommerceDbContext context) =>
{
    
    return context.Products;
})
.WithName("Products")
.WithOpenApi();

app.MapGet("/Products/{id}", (EcommerceDbContext context,int id) =>
{

    return context.Products.FirstOrDefault(p=>p.Id==id);
})
.WithName("Product")
.WithOpenApi();


DbInitilizer.InitDb(app);

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
