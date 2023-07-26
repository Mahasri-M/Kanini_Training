using Microsoft.EntityFrameworkCore;
using WebAPIWithEFDBFirst.Models;
using WebAPIWithEFDBFirst.Repository.StudentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();


builder.Services.AddDbContext<StudentDbContext>
    (optionsAction: options =>
    options.UseSqlServer
    (builder.Configuration.GetConnectionString(name: "SQLConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("UsersCorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("UsersCorsPolicy");

app.UseAuthorization();


app.UseAuthentication();


app.MapControllers();

app.Run();
