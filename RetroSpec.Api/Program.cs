using Microsoft.EntityFrameworkCore;
using RetroSpec.Api.Extensions;
using RetroSpec.Infrastructure.Abstractions;
using RetroSpec.Infrastructure.Extensions;
using Serilog;
using System.Reflection;

const string SpecifiedOriginsPolicyName = "SpecifiedOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration);
    });

builder.Services.AddRetroSpec()
    .AddDatabase(databaseOptions =>
    {
        databaseOptions.AddDatabaseProvider(builder.Configuration.GetValue<string>("DatabaseProvider"), builder.Configuration.GetConnectionString("RetroSpec"));
    })
    .AddBoards();

builder.Services.AddAuthenticationProvider();

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy(SpecifiedOriginsPolicyName, policyBuilder =>
    {
        policyBuilder.WithOrigins(builder.Configuration?.GetSection("AllowedOrigins").Get<string[]>() ?? throw new Exception("Allowed origins not specified for CORS."))
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddRouting(routeOptions =>
{
    routeOptions.LowercaseUrls = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerOptions =>
{
    swaggerOptions.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1.0",
        Title = "Retro API",
        Description = "An API for running retros."
    });

    swaggerOptions.EnableAnnotations();
    swaggerOptions.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    swaggerOptions.SupportNonNullableReferenceTypes();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUIOptions =>
    {
        swaggerUIOptions.SwaggerEndpoint("/swagger/v1.0/swagger.json", "v1.0");
    });
}

app.UseCors(SpecifiedOriginsPolicyName);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.UseSerilogRequestLogging();

app.MapControllers();

using var scope = app.Services.CreateScope();
var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationService>();
migrationService.Migrate();

app.Run();
