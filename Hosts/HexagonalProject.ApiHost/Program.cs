using HexagonalSample.Application.DependencyResolvers;
using HexagonalSample.Persistence.DependencyResolvers;
using HexagonalSample.WebApi.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextService(builder.Configuration);
builder.Services.AddRepositoryService();
builder.Services.AddUseCaseService();

builder.Services.AddControllers().AddApplicationPart(typeof(CategoryController).Assembly); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
