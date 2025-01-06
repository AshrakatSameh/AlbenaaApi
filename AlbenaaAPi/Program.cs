using AlbenaaAPi.Context;
using AlbenaaAPi.Implementation;
using AlbenaaAPi.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(op =>
{
    try
    {
        op.UseSqlServer(builder.Configuration.GetConnectionString("CoursesDb"));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection error: {ex.Message}");
        throw;
    }
});


// Add services to the container.

builder.Services.AddTransient<ICourses, CoursesServices>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
