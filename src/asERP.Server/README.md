# asERP Server

[![asERP.Server](https://github.com/asERP/asERP/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/asERP/asERP/actions/workflows/dotnet.yml)

A headless REST API server for the asERP (Enterprise Resource Planning) system built with .NET 9 and ASP.NET Core.

## Overview

asERP.Server provides the backend API for the asERP system, implementing Clean Architecture principles with CQRS pattern. It supports multi-tenancy and provides RESTful endpoints for all business operations.

## Features

- **Multi-tenant architecture** - Complete tenant isolation
- **JWT Authentication** - Secure token-based authentication
- **Clean Architecture** - Separation of concerns with CQRS
- **Multi-database support** - PostgreSQL, MSSQL, SQLite
- **API Versioning** - Built-in versioning support
- **OpenTelemetry** - Comprehensive observability
- **Swagger/OpenAPI** - API documentation

## Quick Start

### Prerequisites

- .NET 9 SDK
- Supported database (PostgreSQL, MSSQL, or SQLite)

### Running the Server

```bash
dotnet run --project src/asERP.Server/asERP.Server.csproj
```

The API will be available at `https://localhost:5001` by default.

## Database Configuration

### MSSQL
```
DatabaseConfig__ConnectionStrings__MSSQL="Server=dein-server;Database=aserp_01;User Id=user;Password=password;TrustServerCertificate=True;"
```

### PostgreSQL
```
DatabaseConfig__ConnectionStrings__PostgreSQL="Host=dein-server;Port=5432;Database=aserp_01;Username=user;Password=password;"
```

### SQLite
```
DatabaseConfig__ConnectionStrings__SQLite="Data Source=pfad/zu/deiner.db"
```

### Provider Configuration

You can also specify which database provider to use:
```
DatabaseConfig__Provider="SQLite"
```

## API Documentation

Once running, access the Swagger UI at `https://localhost:5001/swagger` for interactive API documentation.

## Multi-Platform Clients

This server works with the following asERP clients:
- **asERP.Client** - Cross-platform Uno Platform app

## License

Open source ERP system developed by Martin Andrich.
