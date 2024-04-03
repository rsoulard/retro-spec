using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RetroSpec.Application.Abstractions;
using RetroSpec.Application.DomainServices;
using RetroSpec.Infrastructure.Abstractions;
using RetroSpec.Infrastructure.DataAccess;
using RetroSpec.Infrastructure.Repositories;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RetroSpec.UnitTests")]
[assembly: InternalsVisibleTo("RetroSpec.SqlServer")]
namespace RetroSpec.Infrastructure;

public class RetroBuilder
{
    public IServiceCollection Services { get; init; }

    public RetroBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public RetroBuilder AddDatabase(Action<DbContextOptionsBuilder> options)
    {
        Services.AddDbContext<RetroDbContext>(options);
        Services.AddScoped<IMigrationService, MigrationService>();
        Services.AddScoped<IUnitOfWork, UnitOfWork>();

        return this;
    }

    public RetroBuilder AddBoards()
    {
        Services.TryAddScoped<IBoardService, BoardService>();
        Services.TryAddScoped<IBoardQueryRepository, BoardQueryRepository>();
        Services.TryAddScoped<IColumnService, ColumnService>();
        Services.TryAddScoped<ICardService, CardService>();
        Services.TryAddScoped<ICardQueryRepository, CardQueryRepository>();

        return this;
    }
}
