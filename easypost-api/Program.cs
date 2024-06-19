using System.Security.Permissions;
using easypost_api.ManageProject.Application.Internal.CommandServices;
using easypost_api.ManageProject.Application.Internal.QueryServices;
using easypost_api.ManageProject.Domain.Repositories;
using easypost_api.ManageProject.Domain.Services;
using easypost_api.ManageProject.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.Poles.Application.CommandServices;
using easypost_api.Poles.Application.Internal.QueryServices;
using easypost_api.Poles.Domain.Repositories;
using easypost_api.Poles.Domain.Services;
using easypost_api.Poles.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.Shared.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options=>options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if(connectionString!=null)
        if (builder.Environment.IsDevelopment())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        else if (builder.Environment.IsProduction())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "EasyPost-Api",
            Version = "v1",
            Description = "EasyPost Web Api",
            Contact = new OpenApiContact
            {
                Name = "InnovaTec",
                Email = "innovatec@gmail.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    c.EnableAnnotations();
});

// Configure Lowercase URLs
builder.Services.AddRouting(options=>options.LowercaseUrls=true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Bounded Context Management Project Injection Configuration

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectQueryService, ProjectQueryService>();
builder.Services.AddScoped<IProjectCommandService, ProjectCommandService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationQueryService, LocationQueryService>();
builder.Services.AddScoped<ILocationCommandService, LocationCommandService>();

// Material Bounded Context Injection Configuration

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMaterialQueryService, MaterialQueryService>();
builder.Services.AddScoped<IMaterialCommandService, MaterialCommandService>();
builder.Services.AddScoped<IProjectMaterialRepository, ProjectMaterialsRepository>();
builder.Services.AddScoped<IProjectMaterialsQueryService, ProjectMaterialsQueryService>();
builder.Services.AddScoped<IProjectMaterialsCommandService, ProjectMaterialsCommandService>();

// Pole Bounded Context Injection Configuration

builder.Services.AddScoped<IPoleRepository, PoleRepository>();
builder.Services.AddScoped<IPoleQueryService, PoleQueryService>();
builder.Services.AddScoped<IPoleCommandService, PoleCommandService>();
builder.Services.AddScoped<IGeoReferenceRepository, GeoReferenceRepository>();
builder.Services.AddScoped<IGeoReferenceQueryService, GeoReferenceQueryService>();
builder.Services.AddScoped<IGeoReferenceCommandService, GeoReferenceCommandService>();

// Bounded Context "2" Injection Configuration

// ....

var app = builder.Build();

using (var scope=app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();*/

app.UseAuthorization();

app.MapControllers();

app.Run();

/*record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/