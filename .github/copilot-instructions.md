# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

asToolkit is a C# client-server, cross-platform, open-source ERP system developed with .NET 9, Avalonia and Entity Framework. It follows the Clean Architecture with a clear separation of concerns. It consists of the projects:

1. **asToolkit.Domain** - Core domain entities and interfaces
2. **asToolkit.Application** - Application logic, CQRS handlers
3. **asToolkit.Infrastructure** - Cross-cutting concerns (email, logging, PDF generation)
4. **asToolkit.Persistence** - Database access, repositories
5. **asToolkit.Identity** - Authentication and authorization
6. **asToolkit.SalesChannels** - Integrations with e-commerce platforms
7. **asToolkit.Server** - Backend API server (headless, no frontend)
8. **asToolkit.UI** - Shared UI components for use in Avalonia applications
9. **asToolkit.UI.Desktop** - Avalonia Desktop Client
10. **asToolkit.UI.Browser** - Avalonia WebAssembly Client
11. **asToolkit.UI.iOS** - Aavalonia iOS App
12. **asToolkit.UI.Android** - Avalonia Android App

## Architecture

The codebase implements:
- CQRS pattern for separating commands and queries
- Repository pattern for data access
- JWT authentication
- No Automapper, using manual mapping instead
- No MediatR, using manual Mediator instead
- Avalonia with CommunityToolkit.MVVM for cross-platform UI
- UI projects not using direct database acces, using REST-API instead

## Development Commands

### Building the Project

```bash
# Build the entire solution
dotnet build

# Build asToolkit.Server project
dotnet build src/asToolkit.Server/asToolkit.Server.csproj

# Build asToolkit.UI.Browser project
dotnet build src/asToolkit.UI.Browser/asToolkit.UI.Browser.csproj

```

### Running the Application

```bash
# Run the server
dotnet run --project src/asToolkit.Server/asToolkit.Server.csproj

# Run the web frontend
dotnet run --project src/asToolkit.UI.Browser/asToolkit.UI.Browser.csproj

# Run the multi-platform client
dotnet run --project src/asToolkit.UI.Desktop/asToolkit.UI.Desktop.csproj
```

### Testing

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test tests/asToolkit.Server.Tests/asToolkit.Server.Tests.csproj

# Run specific test class
dotnet test tests/asToolkit.Server.Tests/asToolkit.Server.Tests.csproj --filter "FullyQualifiedName~CustomerCrudTest"

# Run specific test method
dotnet test tests/asToolkit.Server.Tests/asToolkit.Server.Tests.csproj --filter "FullyQualifiedName~CustomerCrudTest.CustomerCreateTest"
```

### Database Migrations

The project supports multiple database providers (PostgreSQL, MSSQL, SQLite) with separate migration assemblies:

```bash
# Create migrations for all providers
./create-migrations.sh "MigrationName"

# Create migrations for specific provider
./create-migrations.sh "MigrationName" mssql
./create-migrations.sh "MigrationName" postgresql
./create-migrations.sh "MigrationName" sqlite
```

### Code Style and Quality

```bash
# Run code format check
dotnet format --verify-no-changes

# Apply code formatting
dotnet format
```

## Important Notes

- All comments should be in English
- The project uses dependency injection heavily throughout all layers
- Database provider can be configured in appsettings.json or environment variables
- Docker containerization is fully supported and recommended for deployment
- Authentication is JWT-based
- asToolkit.Server is built with .NET 9 ASP.NET Core
- asToolkit.Server uses MediatR for CQRS pattern
- The project is multi tenancy enabled
- The project uses Entity Framework Core for database access
- The project uses C# 10+ features when appropriate
- The project uses FluentValidation for validation
- The project uses Serilog for logging
- The project uses GitHub Actions for CI/CD
- asToolkit.UI is not executable. It is a shared library for asToolkit.Browser, asToolkit.Desktop, asToolkit.iOS and asToolkit.Android
- Avalonia is used for cross-platform UI development
- Avalonia is using CommunityToolkit.MVVM and CompiledBindings
- ViewModels are registered in asToolkit.UI/app.xaml.cs
- DTOs are defined in asToolkit.Domain an available as ListDto, DetailDto and InputDto
- Repositories are defined in asToolkit.Persistence
- Services are defined in asToolkit.Application
- on layout changes, always consider the Avalonia platform limitations and capabilities
- when implementing new features, always consider the cross-platform nature of the project
- when implementing new features, always consider the performance and scalability of the solution
- when implementing new features, always consider the security implications of the solution
- when adding new axaml files, proof if the DataTemplate neeed to be added to MainView.axaml
- IMPORTANT: data isolation of tenants must always be ensured. In most cases with global EF Core query filters.
- IMPORTANT: when implementing new layouts, always heavily think about the user experience and usability
- IMPORTANT: on layout changes, always look if there is a similar layout and write consistent code
- When implementing new features or functions, YOU MUST look if there is a similar feature or function and write consistent code
- Tests are using own Factory-Instances instead of shared Fixtures
- Don't use FluentAssertions
- Use RFC 7807 for problem details