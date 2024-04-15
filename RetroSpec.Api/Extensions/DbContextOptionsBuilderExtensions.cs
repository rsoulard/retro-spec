using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace RetroSpec.Api.Extensions;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder AddDatabaseProvider(this DbContextOptionsBuilder builder, string? providerName, string? connectionString)
    {
        if (string.IsNullOrEmpty(providerName))
        {
            throw new Exception("No database provider configured.");
        }

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("No connection string configured.");
        }

        if (providerName == DatapaseMigrationProvider.SqlServer.providerName)
        {
            ConfigureSqlServer(builder, connectionString);
        }
        else if (providerName == DatapaseMigrationProvider.MariaDb.providerName)
        {
            ConfigureMariaDb(builder, connectionString);
        }
        else
        {
            throw new Exception($"Database provider for {providerName} not available.");
        }

        return builder;
    }

    private static void ConfigureSqlServer(DbContextOptionsBuilder builder, string connectionString)
    {
        builder.UseSqlServer(connectionString, sqlServerOptions =>
        {
            sqlServerOptions.MigrationsAssembly(DatapaseMigrationProvider.SqlServer.migrationAssemblyName);
        });
    }

    private static void ConfigureMariaDb(DbContextOptionsBuilder builder, string connectionString)
    {
        builder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString),
            mySqlOptions =>
            {
                mySqlOptions.MigrationsAssembly(DatapaseMigrationProvider.MariaDb.migrationAssemblyName);
                mySqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore);
            }
        );
    }
}
