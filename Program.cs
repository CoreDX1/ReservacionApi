using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "Reservaciones API",
            Description = "An ASP.NET Core Web API for Reservaciones",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact { Name = "CoreDX1", Url = new Uri("https://example.com") },
            License = new OpenApiLicense
            {
                Name = "Use under MIT",
                Url = new Uri("https://example.com/license")
            }
        }
    );
});
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

// Add the endpoint for the API
app.MapControllers();
app.Run();
