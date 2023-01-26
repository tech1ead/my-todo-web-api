using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyToDoWebApi.Database.Context;
using MyToDoWebApi.Repository.UnitOfWork;
using MyToDoWebApi.Service.CategoryService;
using MyToDoWebApi.Service.ToDoService;

string corsKey = "mySecretCorsKey";
var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddControllers();

// Pre defined services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "TestSwagger", Version = "v1" });
});

//Db Context here
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsKey,
        x => x.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              );
});

var app = builder.Build();

var scope = app.Services.CreateScope();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(corsKey);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
