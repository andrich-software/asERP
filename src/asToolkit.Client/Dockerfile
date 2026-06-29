# Uno Platform WebAssembly Dockerfile
# Build stage with .NET 10 SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# Install python3 required by Emscripten for WASM native compilation
RUN apt-get update && apt-get install -y --no-install-recommends python3 && rm -rf /var/lib/apt/lists/*

WORKDIR /src

# Copy project files for restore
COPY ["src/asToolkit.Client/asToolkit.Client.csproj", "asToolkit.Client/"]
COPY ["src/asToolkit.Domain/asToolkit.Domain.csproj", "asToolkit.Domain/"]
COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["global.json", "./"]
# NuGet.config carries the package sources required to resolve the
# Uno.Sdk MSBuild SDK that's pulled in via global.json's msbuild-sdks.
COPY ["NuGet.config", "./"]

# Install only the wasm-tools workload — the container build targets
# net10.0-browserwasm exclusively. We deliberately do NOT run
# `dotnet workload restore` here: that would force-install Android, iOS,
# MacCatalyst etc. workloads from the multi-target .csproj, all of which
# are unused inside this image.
RUN dotnet workload install wasm-tools

# Restore dependencies for the WASM target only. WasmOnlyBuild=true is
# scoped inside asToolkit.Client.csproj so it only narrows that project's
# TargetFrameworks — referenced libraries (e.g. asToolkit.Domain) keep their
# own targets untouched.
RUN dotnet restore "asToolkit.Client/asToolkit.Client.csproj" -p:WasmOnlyBuild=true

# Copy source files
COPY src/asToolkit.Client/ asToolkit.Client/
COPY src/asToolkit.Domain/ asToolkit.Domain/

# Build and publish for browser-WASM only.
WORKDIR "/src/asToolkit.Client"
RUN dotnet publish "asToolkit.Client.csproj" \
    -c Release \
    -f net10.0-browserwasm \
    -p:WasmOnlyBuild=true \
    -o /app/publish

# Runtime stage with nginx
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Copy published WASM files
COPY --from=build /app/publish/wwwroot .

# Ensure every file is world-readable and every directory is traversable.
# `dotnet publish` occasionally emits assets in the package_* directory
# (notably AppManifest.js) with restrictive modes that block the nginx
# worker user, leading to 403s when the browser requests them.
RUN chmod -R a+rX /usr/share/nginx/html

# Copy custom nginx config for SPA routing
COPY src/asToolkit.Client/nginx.conf /etc/nginx/conf.d/default.conf

# Runtime config generator — writes /usr/share/nginx/html/config.json from
# env vars before nginx starts. Picked up by /docker-entrypoint.d/.
COPY src/asToolkit.Client/docker-entrypoint.d/10-write-config.sh /docker-entrypoint.d/10-write-config.sh
RUN chmod +x /docker-entrypoint.d/10-write-config.sh

EXPOSE 80

# Use 127.0.0.1, not localhost: localhost resolves to ::1 (IPv6) in the
# container while nginx listens on IPv4 — a localhost healthcheck would get
# "connection refused" and report the container unhealthy.
HEALTHCHECK --interval=30s --timeout=3s \
    CMD wget --no-verbose --tries=1 --spider http://127.0.0.1:80/ || exit 1
