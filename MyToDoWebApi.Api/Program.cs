using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyToDoWebApi.Database.Context;
using MyToDoWebApi.Repository.UnitOfWork;
using MyToDoWebApi.Service.CategoryService;
using MyToDoWebApi.Service.ToDoService;
using System.Reflection;

string corsKey = "_mySecretCorsKey";
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

// Configure appsettings.json DbContext
string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
AppDomain.CurrentDomain.SetData("DataDirectory", baseDirectory);
string connectionString = configuration.GetConnectionString("ToDoConnection")!
    .Replace("|DataDirectory|", AppDomain.CurrentDomain
    .GetData("DataDirectory")!
    .ToString());

//Db Context here
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlServer(connectionString)
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

// Migrate Database
// Apply Migrations using this command
// Add-Migration [Name] -StartupProject MyToDoWebApi.Api -Context ToDoContext -Project MyToDoWebApi.Database
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ToDoContext>();
context.Database.Migrate();

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