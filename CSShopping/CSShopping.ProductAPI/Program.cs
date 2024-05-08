using AutoMapper;
using CSShopping.ProductAPI.Config;
using CSShopping.ProductAPI.Model.Context;
using CSShopping.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSShopping.ProductAPI", Version = "v1" });
});

builder.Services.AddDbContext<SQLServerContext>(options =>
{
    options.UseSqlServer(configuration["SqlConnection:sqlConnectionString"]);
});

IMapper mapper = MappingConfig.MapperConfiguration().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.DependencyInjectionConfiguration();


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
