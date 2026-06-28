#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8443

# libgssapi-krb5-2 is needed by Npgsql so it doesn't log
# "Cannot load library libgssapi_krb5.so.2" on every startup.
RUN apt-get update \
    && apt-get install -y --no-install-recommends libgssapi-krb5-2 \
    && rm -rf /var/lib/apt/lists/*

ENV DatabaseConfig__Provider=Sqlite
ENV DatabaseConfig__ConnectionString=Data Source=astoolkit.db

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Directory.Packages.props", "/src/"]
COPY ["Directory.Build.props", "/src/"]
COPY ["src/asToolkit.Server/asToolkit.Server.csproj", "asToolkit.Server/"]
COPY ["src/asToolkit.Application/asToolkit.Application.csproj", "asToolkit.Application/"]
COPY ["src/asToolkit.Domain/asToolkit.Domain.csproj", "asToolkit.Domain/"]
COPY ["src/asToolkit.Analytics/asToolkit.Analytics.csproj", "asToolkit.Analytics/"]
COPY ["src/asToolkit.Identity/asToolkit.Identity.csproj", "asToolkit.Identity/"]
COPY ["src/asToolkit.Infrastructure/asToolkit.Infrastructure.csproj", "asToolkit.Infrastructure/"]
COPY ["src/asToolkit.Persistence/asToolkit.Persistence.csproj", "asToolkit.Persistence/"]
COPY ["src/asToolkit.Persistence.MSSQL/asToolkit.Persistence.MSSQL.csproj", "asToolkit.Persistence.MSSQL/"]
COPY ["src/asToolkit.Persistence.PostgreSQL/asToolkit.Persistence.PostgreSQL.csproj", "asToolkit.Persistence.PostgreSQL/"]
COPY ["src/asToolkit.Persistence.SQLite/asToolkit.Persistence.SQLite.csproj", "asToolkit.Persistence.SQLite/"]
COPY ["src/asToolkit.SalesChannels/asToolkit.SalesChannels.csproj", "asToolkit.SalesChannels/"]
RUN dotnet restore "asToolkit.Server/asToolkit.Server.csproj"
COPY src/ .
WORKDIR "/src/asToolkit.Server"
RUN dotnet build "asToolkit.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "asToolkit.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

HEALTHCHECK --interval=30s --timeout=3s \
    CMD wget --no-verbose --tries=1 --spider http://localhost:8443/health || exit 1

ENTRYPOINT ["dotnet", "asToolkit.Server.dll"]
