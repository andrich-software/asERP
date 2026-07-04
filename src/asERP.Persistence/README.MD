## Add Migration

## Database migration

### MSSQL
```bash
dotnet ef migrations add initDb --project src/asERP.Persistence.MSSQL/asERP.Persistence.MSSQL.csproj --startup-project src/asERP.Server/asERP.Server.csproj --context asERP.Persistence.DatabaseContext.ApplicationDbContext --configuration Debug --output-dir Migrations
```

### PostgreSQL
```bash
dotnet ef migrations add initDb --project src/asERP.Persistence.PostgreSQL/asERP.Persistence.PostgreSQL.csproj --startup-project src/asERP.Server/asERP.Server.csproj --context asERP.Persistence.DatabaseContext.ApplicationDbContext --configuration Debug --output-dir Migrations

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