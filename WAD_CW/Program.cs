using Microsoft.EntityFrameworkCore;
using SPI.Data;
using SPI.Models;
using SPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SparePartsInventoryDBContext>(
    o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IRepository<SparePart>, SparePartsRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Supplier>, SupplierRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
