namespace RetroSpec.Api
{
    public record DatapaseMigrationProvider(string providerName, string migrationAssemblyName)
    {
        public static readonly DatapaseMigrationProvider SqlServer = new(nameof(SqlServer), typeof(SqlServer.MigrationMarker).Assembly.GetName().Name!);
        public static readonly DatapaseMigrationProvider MariaDb = new(nameof(MariaDb), typeof(MariaDb.MigrationMarker).Assembly.GetName().Name!);
    }
}
