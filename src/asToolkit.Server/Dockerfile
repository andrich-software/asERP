#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8443

# libgssapi-krb5-2 is needed by Npgsql so it doesn't log
# "Cannot load library libgssapi_krb5.so.2" on every startup.
# curl is needed for the HEALTHCHECK below — the aspnet image ships neither
# curl nor wget, so the healthcheck would otherwise always fail.
RUN apt-get update \
    && apt-get install -y --no-install-recommends libgssapi-krb5-2 curl \
    && rm -rf /var/lib/apt/lists/*

ENV DatabaseConfig__Provider=Sqlite
ENV DatabaseConfig__ConnectionString=Data Source=astoolkit.db

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
# Tame the build's memory footprint on small/loaded hosts: workstation GC instead
# of per-core server heaps, and pretend to have 2 cores so MSBuild's Copy task and
# friends don't spawn a thread per real core. Prevents OutOfMemory/SIGBUS during
# the build on memory-constrained machines.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_NOLOGO=1 \
    DOTNET_gcServer=0 \
    DOTNET_PROCESSOR_COUNT=2
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
# publish builds the project itself — no need for a separate `dotnet build` pass.
# -m:1 + BuildInParallel=false build the projects serially to avoid memory spikes.
RUN dotnet publish "asToolkit.Server.csproj" -c Release -o /app/publish \
    /p:UseAppHost=false -m:1 -p:BuildInParallel=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Use 127.0.0.1, not localhost: localhost resolves to ::1 (IPv6) in the
# container while Kestrel may listen on IPv4 only — a localhost healthcheck
# could get "connection refused" and report the container unhealthy.
HEALTHCHECK --interval=30s --timeout=3s \
    CMD curl -fsS http://127.0.0.1:8443/health || exit 1

ENTRYPOINT ["dotnet", "asToolkit.Server.dll"]
