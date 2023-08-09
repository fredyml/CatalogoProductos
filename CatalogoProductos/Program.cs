using CatalogoProductos.Aplication.Interfaces;
using CatalogoProductos.Aplication.Services;
using CatalogoProductos.Infra.Persistence.Repository;
using CatalogoProductos.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using CatalogoProductos.Filters;
using NLog.Web;
using CatalogoProductos.Infra.Logger;
using CatalogoProductos.Aplication.Dtos;
using CatalogoProductos.Aplication.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

builder.Services.AddControllers();

builder.Services.AddDbContext<CatalogContext>();
builder.Services.AddScoped<IImageValidator, ImageValidator>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

Context.ConnectionString = (builder.Configuration.GetConnectionString("CatalogoProductosConnection"));
builder.Services.AddDbContext<CatalogContext>(options =>
    options.UseSqlServer(Context.ConnectionString));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Host.UseNLog();

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
