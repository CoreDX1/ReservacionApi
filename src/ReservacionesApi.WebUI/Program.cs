using ReservacionesApi.Application.Extensions;
using ReservacionesApi.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add services to the container.
builder.Services.AddControllers();

var AllowOrigins = "AllowOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: AllowOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});

var configuration = builder.Configuration;

// add services to the container.
builder.Services.AddPersistenceServices(configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddRouting(r => r.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservacionesApi API");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors(AllowOrigins);

app.UseHttpsRedirection();

// add endpoints for the API
app.MapControllers();
app.Run();
