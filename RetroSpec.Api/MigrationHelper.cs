namespace RetroSpec.Api
{
    public record MigrationProvider(string providerName, string migrationAssemblyName)
    {
        public static readonly MigrationProvider SqlServer = new(nameof(SqlServer), typeof(SqlServer.MigrationMarker).Assembly.GetName().Name!);
    }
}
