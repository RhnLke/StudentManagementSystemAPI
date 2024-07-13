using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(type => type.FullName.Replace("+", "."));
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentManagementSystem.Api", Version = "v1" });
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("local"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient(c => c.GetService<IHttpContextAccessor>().HttpContext?.User);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
