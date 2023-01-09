using Microsoft.EntityFrameworkCore;
using WebApiProduct.DbContexts;
using AutoMapper;
using WebApiProduct;
using WebApiProduct.Repository;
using Serilog;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuracion del DBContext
var connectionString = builder.Configuration.GetConnectionString("ProductDB");
builder.Services
    .AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//Configuracion para Serilog
builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration)
    .WriteTo.Console();
});

builder.Services.AddControllers();

//Configuracion del AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Dependency Inyection
builder.Services.AddScoped<IProductRepository, ProductSQLRepository>();

// Memory Cache Inyection
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
