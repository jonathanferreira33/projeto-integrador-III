
using Auth.Data;
using Microsoft.EntityFrameworkCore;
using PI.Data_Access.Context;
using PI.Data_Access.Mapping;
using PI.Data_Access.Repository;
using PI.Domain.Interfaces;
using PI.Domain.Interfaces.Services;
using PI.Domain.Mapping;
using PI.Service;
using System;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen();

//services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddMemoryCache();

var connectionString = builder.Configuration["ConnectionStrings:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(
    options => options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString))
);

//repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Integrador II");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

try
{
    //The code that causes the error goes here.
    app.MapControllers();
}
catch (ReflectionTypeLoadException ex)
{
    StringBuilder sb = new StringBuilder();
    foreach (Exception exSub in ex.LoaderExceptions)
    {
        sb.AppendLine(exSub.Message);
        FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
        if (exFileNotFound != null)
        {
            if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
            {
                sb.AppendLine("Fusion Log:");
                sb.AppendLine(exFileNotFound.FusionLog);
            }
        }
        sb.AppendLine();
    }
    string errorMessage = sb.ToString();
    //Display or log the error based on your application.
}

app.Run();
