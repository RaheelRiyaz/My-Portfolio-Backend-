using New_Portfolio_Backend_.DIContainer;
using Portfolio.Core.DIContainer;
using Portfolio.Infrastructure.DIContainer;
using Portfolio.Persistence.DIContainer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiServices(builder.Configuration)
    .AddPersistenceServices(builder.Configuration).
    AddInfraStructureServices(builder.Configuration).
    AddApplicationServices(builder.Environment.WebRootPath);
var app = builder.Build();
app.UseStaticFiles();
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
