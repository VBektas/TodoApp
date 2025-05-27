using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Interfaces;
using TodoApp.Services;
using TodoApp.Validators;

var builder = WebApplication.CreateBuilder(args);



// Connection string'i appsettings.json üzerinden oku
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i DI sistemine kaydet
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)); 

builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// servis ayaða kalkarken migration uygulanýr.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); 
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

