using Assesment_ProductManagementSystem_Usman.AutoMapper;
using Assesment_ProductManagementSystem_Usman.Context;
using Assesment_ProductManagementSystem_Usman.GenericRepository;
using Assesment_ProductManagementSystem_Usman.Middleware;
using Assesment_ProductManagementSystem_Usman.Services.Product;
using Assesment_ProductManagementSystem_Usman.Services.Product.DTOs;
using Assesment_ProductManagementSystem_Usman.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MainContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<ExceptionHandling>();
builder.Services.AddScoped(typeof (IRepository<>), typeof (Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseMiddleware<ExceptionHandling>();
app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/api/product/getAll", ([FromBody] ProductFilterDTO input, IProductService productService) => Results.Ok(productService.GetAll(input)));
app.MapPost("/api/product/save", ([FromBody] ProductDTO input, IProductService productService) => Results.Ok(productService.Save(input)));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
