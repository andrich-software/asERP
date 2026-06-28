## Add Migration

## Database migration

### MSSQL
```bash
dotnet ef migrations add initDb --project src/asToolkit.Persistence.MSSQL/asToolkit.Persistence.MSSQL.csproj --startup-project src/asToolkit.Server/asToolkit.Server.csproj --context asToolkit.Persistence.DatabaseContext.ApplicationDbContext --configuration Debug --output-dir Migrations
```

### PostgreSQL
```bash
dotnet ef migrations add initDb --project src/asToolkit.Persistence.PostgreSQL/asToolkit.Persistence.PostgreSQL.csproj --startup-project src/asToolkit.Server/asToolkit.Server.csproj --context asToolkit.Persistence.DatabaseContext.ApplicationDbContext --configuration Debug --output-dir Migrations

```

### Apply Migration
```
dotnet ef database update
```

## Install dotnet-ef on macos

```bash
dotnet tool install --global dotnet-ef
export PATH="$PATH:/Users/'your user folder'/.dotnet/tools"
```

## Update dotnet tools
```bash
dotnet tool update --global dotnet-ef
```