using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RetroSpec.Api;
using RetroSpec.Infrastructure.Abstractions;
using RetroSpec.Infrastructure.Extensions;
using System.Reflection;

const string SpecifiedOriginsPolicyName = "SpecifiedOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRetroSpec()
    .AddDatabase(databaseOptions =>
    {
        var provider = builder.Configuration.GetValue("DatabaseProvider", MigrationProvider.SqlServer.providerName);

        if (provider == MigrationProvider.SqlServer.providerName)
        {
            databaseOptions.UseSqlServer(builder.Configuration.GetConnectionString("RetroSpec"), sqlServerOptions =>
            {
                sqlServerOptions.MigrationsAssembly(MigrationProvider.SqlServer.migrationAssemblyName);
            });
        }

        if (provider == MigrationProvider.MariaDb.providerName)
        {
            databaseOptions.UseMySql(
                builder.Configuration.GetConnectionString("RetroSpec"), 
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("RetroSpec")), 
                mySqlOptions =>
            {
                mySqlOptions.MigrationsAssembly(MigrationProvider.MariaDb.migrationAssemblyName);
                mySqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore);
            });
        }
    })
    .AddBoards();

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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors(SpecifiedOriginsPolicyName);

app.MapControllers();

using var scope = app.Services.CreateScope();
var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationService>();
migrationService.Migrate();

app.Run();
