using Rampart_BackEnd.Chefs.Application.Internal.CommandServices;
using Rampart_BackEnd.Chefs.Application.Internal.QueryServices;
using Rampart_BackEnd.Chefs.Domain.Repositories;
using Rampart_BackEnd.Chefs.Domain.Services;
using Rampart_BackEnd.Chefs.Infrastructure.Repositories;
using Rampart_BackEnd.Orders.Application.Internal.CommandServices;
using Rampart_BackEnd.Orders.Application.Internal.QueryServices;
using Rampart_BackEnd.Orders.Domain.Repositories;
using Rampart_BackEnd.Orders.Domain.Services;
using Rampart_BackEnd.Shared.Domain.Repositories;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;
using Rampart_BackEnd.Posts.Application.Internal.CommandServices;
using Rampart_BackEnd.Posts.Application.Internal.QueryServices;
using Rampart_BackEnd.Posts.Domain.Repositories;
using Rampart_BackEnd.Posts.Domain.Services;
using Rampart_BackEnd.Posts.Infrastructure.Repositories;
using Rampart_BackEnd.Dishes.Application.Internal.CommandService;
using Rampart_BackEnd.Dishes.Application.Internal.QueryServices;
using Rampart_BackEnd.Dishes.Domain.Repositories;
using Rampart_BackEnd.Dishes.Domain.services;
using Rampart_BackEnd.Dishes.Infrastructure.Persistence.EFC.Repositories;
using Rampart_BackEnd.IAM.Application.Internal.CommandServices;
using Rampart_BackEnd.IAM.Application.Internal.OutboundServices;
using Rampart_BackEnd.IAM.Application.Internal.QueryServices;
using Rampart_BackEnd.IAM.Domain.Repositories;
using Rampart_BackEnd.IAM.Domain.Services;
using Rampart_BackEnd.IAM.Infrastructure.Hashing.BCrypt.Services;
using Rampart_BackEnd.IAM.Infrastructure.Persistence.EFC.Repositories;
using Rampart_BackEnd.IAM.Infrastructure.Pipeline.Extensions;
using Rampart_BackEnd.IAM.Infrastructure.Tokens.JWT.Configuration;
using Rampart_BackEnd.IAM.Infrastructure.Tokens.JWT.Services;
using Rampart_BackEnd.IAM.Interfaces.ACL;
using Rampart_BackEnd.IAM.Interfaces.ACL.Services;
using Rampart_BackEnd.Orders.Infrastructure.Persistence.EFC.Repositories;
using Rampart_BackEnd.Shared.Infrastructure.Interfaces.ASP.Configuration; 
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
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
builder.Services.AddSwaggerGen(options =>
{
        
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Rampart.API",
            Version = "v1",
            Description = "Rampart Company API",
            TermsOfService = new Uri("https://Rampart.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "Rampart",
                Email = "contact@acme.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.EnableAnnotations();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
builder.Services.AddRouting(options => options.LowercaseUrls = true);


// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


// Configure Dependency Injection
// Bounded Context Injection Configuration for Business
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Order Bounded Context
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();

// Dish Bounded Context
builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IDishQueryService, DishQueryService>();
builder.Services.AddScoped<IDishCommandService, DishCommandService>();

// Chef Bounded Context
builder.Services.AddScoped<IChefRepository, ChefRepository>();
builder.Services.AddScoped<IChefQueryService, ChefQueryService>();
builder.Services.AddScoped<IChefCommandService, ChefCommandService>();

// Post Bounded Context
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostQueryService, PostQueryService>();
builder.Services.AddScoped<IPostCommandService, PostCommandService>();

//  IAM Bounded Context Injection Configuration

// TokenSettings Configuration

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryServices, UserQueryServices>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();
/////////////////////////End Database Configuration/////////////////////////
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Handle migrations
}


//***********************(Deploy backend)************************
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEnd v1");
        c.RoutePrefix = string.Empty; // Esto hace que Swagger esté disponible en la raíz
    });
}
//***********************(Deploy backend)************************

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

// Add Authorization Middleware to Pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

