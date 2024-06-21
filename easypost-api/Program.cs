using easypost_api.IAM.Application.Internal.CommandServices;
using easypost_api.IAM.Application.Internal.OutboundServices;
using easypost_api.IAM.Application.Internal.QueryServices;
using easypost_api.IAM.Domain.Repositories;
using easypost_api.IAM.Domain.Services;
using easypost_api.IAM.Infrastructure.Hashing.BCrypt.Services;
using easypost_api.IAM.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using easypost_api.IAM.Infrastructure.Tokens.JWT.Configuration;
using easypost_api.IAM.Infrastructure.Tokens.JWT.Services;
using easypost_api.IAM.Interfaces.ACL;
using easypost_api.IAM.Interfaces.ACL.Services;
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
using easypost_api.Requests.Application.Internal.CommandServices;
using easypost_api.Requests.Application.Internal.QueryServices;
using easypost_api.Requests.Domain.Repositories;
using easypost_api.Requests.Domain.Services;
using easypost_api.Requests.Infrastructure.Persistence.EFC.Repositories;
using easypost_api.Tickets.Infrastructure.Persistence.EFC.Repositories;
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
    c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

// Configure Lowercase URLs
builder.Services.AddRouting(options=>options.LowercaseUrls=true);

// Configure CORS Service
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

// Bounded Context "Profiles" Injection Configuration

builder.Services.AddScoped<IProfileRepository,ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService,ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService,ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade,ProfilesContextFacade>();

// TokenSettings Configuration 

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

// Bounded Context "Users" Injection Configuration

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserContextFacade, UserContextFacade>();
builder.Services.AddScoped<IUserCommandService,UserCommandService>();
builder.Services.AddScoped<IUserQueryService,UserQueryService>();
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddScoped<IHashingService,HashingService>();

// Bounded Context "Requests" Injection Configuration
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestCommandService, RequestCommandService>();
builder.Services.AddScoped<IRequestQueryService, RequestQueryService>();

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

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
