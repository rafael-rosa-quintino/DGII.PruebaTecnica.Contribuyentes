using DGII.PruebaTecnica.Contribuyentes.API.DependecyInjection;
using DGII.PruebaTecnica.Contribuyentes.Application;
using DGII.PruebaTecnica.Contribuyentes.Domain.DependencyInjection;
using DGII.PruebaTecnica.Contribuyentes.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services
    .AddDomain(builder.Configuration)
    .AddInfrastucture(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddApiCors(builder.Configuration)
    .AddLogger(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
