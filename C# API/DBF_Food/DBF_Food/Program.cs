using DBF_Food.Models;
using DBF_Food.Repository.Category_Services;
using DBF_Food.Repository.Customerdet_Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ICategory, CategorySer>();
//builder.Services.AddScoped<ICusDet, CusDetSer>();

builder.Services.AddDbContext<FoodContext>
    (optionsAction: options => options.UseSqlServer
    (builder.Configuration.GetConnectionString(name: "SQLConnection")));


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
