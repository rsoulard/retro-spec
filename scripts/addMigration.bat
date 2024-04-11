@echo off
set migrationName=%1

echo Building Sql Server migrations
dotnet ef migrations add %migrationName% --startup-project ..\RetroSpec.Api\RetroSpec.Api.csproj --project ..\RetroSpec.SqlServer\RetroSpec.SqlServer.csproj -- --DatabaseProvider SqlServer

echo Building Maria Db migrations
dotnet ef migrations add %migrationName% --startup-project ..\RetroSpec.Api\RetroSpec.Api.csproj --project ..\RetroSpec.MariaDb\RetroSpec.MariaDb.csproj -- --DatabaseProvider MariaDb
