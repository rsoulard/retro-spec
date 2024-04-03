using Microsoft.EntityFrameworkCore;
using RetroSpec.Infrastructure.Abstractions;
using RetroSpec.Infrastructure.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRetroSpec()
    .AddDatabase(databaseOptions =>
    {
        databaseOptions.UseSqlServer(builder.Configuration.GetConnectionString("RetroSpec"), sqlServerOptions =>
        {
            sqlServerOptions.MigrationsAssembly(typeof(RetroSpec.SqlServer.MigrationMarker).Assembly.GetName().Name);
        });
    })
    .AddBoards();

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
app.MapControllers();

using var scope = app.Services.CreateScope();
var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationService>();
migrationService.Migrate();

app.Run();
