using Backend_TeaTech.Infrastructure;
using Backend_TeaTech.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Services;
using Backend_TeaTech.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddTransient<IChildAssistedRepository, ChildAssistedRepository>();
builder.Services.AddTransient<IResponsibleRepository, ResponsibleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IResponsibleService, ResponsibleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IChildAssistedService, ChildAssistedService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IPreAnalysisRepository, PreAnalysisRepository>();
builder.Services.AddTransient<IPreAnalysisService, PreAnalysisService>();
builder.Services.TryAddScoped<IJwtService, JwtService>();
builder.Services.AddTransient<IAssessmentService, AssessmentService>();
builder.Services.AddTransient<IAssessmentRepository, AssessmentRepository>();
builder.Services.AddTransient<IProgramAssistedService, ProgramAssistedService>();
builder.Services.AddTransient<IProgramAssistedRepository, ProgramAssistedRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Tea Tech API",
        Description = "This API provides endpoints for managing employees and all processes within the Tea Tech organization."
    });

    var xmlFile = "Backend_TeaTech.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Header authorization JWT is using Bearer scheme. \r\n\r\n Type 'Bearer' before placing the Token"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
        
    });
    
});

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ?? string.Empty))
        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CoordinatorOrApplicator", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context =>
        {
            var roles = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return roles.Contains("Employee:Coordinator") || roles.Contains("Employee:Applicator");
        });
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CoordinatorOrResponsible", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context =>
        {
            var roles = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return roles.Contains("Employee:Coordinator") || roles.Contains("Responsible");
        });
    });
});

builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
