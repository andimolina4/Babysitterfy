global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
using BabysitterfyApp.Business.Services.BabySitterService;
using BabysitterfyApp.DataAccess.Data;
using BabysitterfyApp.DataAccess.Repositories.BabySitterRepository;
using BabysitterfyApp.Helper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
//Connect to DB
builder.Services.AddDbContext<BabySitterAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Add Repositories and Services
builder.Services.AddScoped<IBabySitterRepository, BabySitterRepository>();
builder.Services.AddScoped<IBabySitterService, BabySitterService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
