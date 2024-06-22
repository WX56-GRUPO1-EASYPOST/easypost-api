using System.Security.Permissions;
using easypost_api.DailyActivities.Application.Internal.CommandServices;
using easypost_api.DailyActivities.Application.Internal.QueryServices;
using easypost_api.DailyActivities.Domain.Repositories;
using easypost_api.DailyActivities.Domain.Services;
using easypost_api.DailyActivities.Infrastructure.Persistence.Repositories;
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
using easypost_api.IAM.Application.Internal.CommandServices;
using easypost_api.IAM.Application.Internal.QueryServices;
using easypost_api.IAM.Domain.Repositories;
using easypost_api.IAM.Domain.Services;
using easypost_api.IAM.Infrastructurre.Persistence.EFC.Repositories;
using easypost_api.IAM.Interfaces.ACL;
using easypost_api.IAM.Interfaces.ACL.Services;
using easypost_api.ManageProject.Interfaces.ACL;
using easypost_api.ManageProject.Interfaces.ACL.Services;
using easypost_api.Profiles.Application.Internal.CommandServices;
using easypost_api.Profiles.Application.Internal.QueryServices;
using easypost_api.Profiles.Domain.Repositories;
using easypost_api.Profiles.Domain.Services;
using easypost_api.Profiles.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.Profiles.Interfaces.ACL;
using easypost_api.Profiles.Interfaces.ACL.Services;
using easypost_api.Shared.Domain.Repositories;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.Shared.Interfaces.ASP.Configuration;
using easypost_api.Tickets.Application.Internal.CommandServices;
using easypost_api.Tickets.Application.Internal.QueryServices;
using easypost_api.Tickets.Domain.Repositories;
using easypost_api.Tickets.Domain.Services;
using easypost_api.Tickets.Infrastructurre.Persistence.EFC.Repositories;
using easypost_api.Requests.Application.Internal.CommandServices;
using easypost_api.Requests.Application.Internal.QueryServices;
using easypost_api.Requests.Domain.Repositories;
using easypost_api.Requests.Domain.Services;
using easypost_api.Requests.Infrastructure.Persistence.EFC.Repositories;
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

//Configure CORS Service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


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
builder.Services.AddScoped<ILocationContextFacade, LocationContextFacade>();

// Material Bounded Context Injection Configuration

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMaterialQueryService, MaterialQueryService>();
builder.Services.AddScoped<IMaterialCommandService, MaterialCommandService>();
builder.Services.AddScoped<IProjectMaterialRepository, ProjectMaterialsRepository>();
builder.Services.AddScoped<IProjectMaterialsQueryService, ProjectMaterialsQueryService>();
builder.Services.AddScoped<IProjectMaterialsCommandService, ProjectMaterialsCommandService>();
builder.Services.AddScoped<IProjectContextFacade, ProjectContextFacade>();

// Pole Bounded Context Injection Configuration

builder.Services.AddScoped<IPoleRepository, PoleRepository>();
builder.Services.AddScoped<IPoleQueryService, PoleQueryService>();
builder.Services.AddScoped<IPoleCommandService, PoleCommandService>();
builder.Services.AddScoped<IGeoReferenceRepository, GeoReferenceRepository>();
builder.Services.AddScoped<IGeoReferenceQueryService, GeoReferenceQueryService>();
builder.Services.AddScoped<IGeoReferenceCommandService, GeoReferenceCommandService>();

// Daily Activities Bounded Context Injection Configuration

builder.Services.AddScoped<IDailyActivityRepository, DailyActivityRepository>();
builder.Services.AddScoped<IDailyActivityQueryService, DailyActivityQueryService>();
builder.Services.AddScoped<IDailyActivityCommandService, DailyActivityCommandService>();

// Bounded Context "Profiles" Injection Configuration

builder.Services.AddScoped<IProfileRepository,ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService,ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService,ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade,ProfilesContextFacade>();

// Bounded Context "Users" Injection Configuration

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserContextFacade, UserContextFacade>();
builder.Services.AddScoped<IUserCommandService,UserCommandService>();
builder.Services.AddScoped<IUserQueryService,UserQueryService>();

// Bounded Context "Requests" Injection Configuration
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestCommandService, RequestCommandService>();
builder.Services.AddScoped<IRequestQueryService, RequestQueryService>();
//builder.Services.AddScoped<IRequestsContextFacade, RequestsContextFacade>();

// Bounded Context "Tickets" Injection Configuration
builder.Services.AddScoped<ITicketRepository,TicketRepository>();
builder.Services.AddScoped<ITicketCommandService,TicketCommandService>();
builder.Services.AddScoped<ITicketQueryService,TicketQueryService>();

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

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
