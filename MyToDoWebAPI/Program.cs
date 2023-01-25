using Microsoft.OpenApi.Models;

string corsKey = "mySecretCorsKey";
var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddControllers();

// Pre defined services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "TestSwagger", Version = "v1" });
});

//Db Context here

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsKey,
        x => x.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              );
});

var app = builder.Build();

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