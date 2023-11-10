using Application;
using Application.Abstractions.Auth;
using Application.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var services = builder.Services;
services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(swagger =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Description = "Raw JWT Bearer token",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    swagger.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new List<string>() }
    });
});

var connectionString = configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<TrainingDbContext>(options => options.UseSqlite(connectionString));

// Rejstracja servisow
services.AddApplication(configuration);

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<TrainingDbContext>();
await dbContext.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<AuthMiddleware>();
app.MapControllers();

app.Run();