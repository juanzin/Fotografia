using Microsoft.EntityFrameworkCore;
using Photography_WebAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        //Puestos comunes de React - Vite
        policy.WithOrigins("http://localhost:3000", "http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
