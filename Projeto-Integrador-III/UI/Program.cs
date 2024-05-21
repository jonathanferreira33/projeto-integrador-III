using Auth.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PI.Data_Access.Context;
using PI.Data_Access.Repository;
using PI.Domain.Interfaces;
using PI.Domain.Interfaces.Services;
using PI.Domain.Mapping;
using PI.Service;
using System.Configuration;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers(op => op.RespectBrowserAcceptHeader = false);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT é a sigla para JSON Web Token e trata-se de um formato compacto e autossuficiente para representar informações entre duas partes de maneira segura como um objeto JSON. Bearer",
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",

                }
            },
            new string[] {}
        }
    });
}

);

//services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddMemoryCache();

var connectionString = builder.Configuration["ConnectionStrings:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(
    options => options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString))
);

//repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//autenticacao
builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                builder.Configuration["JwtSettings:Key"]!
                )
            ),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

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

app.UseCors("Policy");

app.UseHttpsRedirection();

app.UseAuthentication();

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
