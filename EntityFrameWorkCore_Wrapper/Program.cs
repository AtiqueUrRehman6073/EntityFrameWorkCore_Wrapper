using EFWrapper_Data_Access.DbContext;
using EFWrapper_Engine.Resources.Implementation;
using EFWrapper_Engine.Resources.Interfaces;
using EntityFrameWorkCore_Wrapper.Extensions;
using ERWrapper_Repositroy.DemoDateRepo.Implementation;
using ERWrapper_Repositroy.DemoDateRepo.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EntityFrameWorkCore_Wrapper",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
     {
       new OpenApiSecurityScheme
       {
         Reference = new OpenApiReference
         {
           Type = ReferenceType.SecurityScheme,
           Id = "Bearer"
         }
        },
        new string[] { }
      }
    });
});
////////     Configure Authentication Pipeline    /////////
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(options =>
{
    //x.ClaimsIssuer = builder.Configuration["Jwt:Issuer"];
    options.Audience = builder.Configuration["Jwt:Audience"];
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,//builder.Configuration["Jwt:Audience"]
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.ConfigureCors();
builder.Services.ConfigureServices();
builder.Services.ConfigureSettings(builder.Configuration);
builder.Services.AddApplicationInsightsTelemetry();
//var aiOptions = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions();

//// Ensables adaptive sampling.
//aiOptions.EnableAdaptiveSampling = true;

//// Ensables QuickPulse (Live Metrics stream).
//aiOptions.EnableQuickPulseMetricStream = true;
//aiOptions.EnablePerformanceCounterCollectionModule = true;
//aiOptions.EnableRequestTrackingTelemetryModule = true;
//aiOptions.EnableEventCounterCollectionModule = true;
//aiOptions.EnableDependencyTrackingTelemetryModule = true;
//aiOptions.EnableAppServicesHeartbeatTelemetryModule = true;
//aiOptions.RequestCollectionOptions.TrackExceptions = true;
//aiOptions.EnableDiagnosticsTelemetryModule = true;
//aiOptions.DeveloperMode = false;

//builder.Services.AddApplicationInsightsTelemetry(aiOptions);
builder.Services.AddApplicationInsightsTelemetryProcessor<ITelemetryProcessor>();
var app = builder.Build();
app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
