using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Services;
using asERP.Application.Models.Storage;
using asERP.Domain.Entities;
using asERP.Identity.Services;
using asERP.Infrastructure.Storage;
using asERP.Persistence.Configurations.Options;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Services.Backup;
using asERP.Server.Infrastructure.Configuration;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Text.Json;

namespace asERP.Server.Cli;

// Out-of-band CLI entrypoint, invoked when the server binary is launched with
// "cli" as its first argument (see Program.cs). Registers a minimal slice of
// the server's DI graph (DbContext + Identity + DataProtection) so we can
// drive UserManager / RoleManager without spinning up Kestrel.
internal static class CliRunner
{
    private const string SuperadminRole = "Superadmin";
    private const string UserRole = "User";

    public static async Task<int> RunAsync(string[] args)
    {
        if (args.Length == 0)
        {
            PrintHelp();
            return 1;
        }

        var hostBuilder = Host.CreateApplicationBuilder();
        // The CLI must operate on the same database as the service — layer the
        // operator-editable settings file exactly like Program.cs does.
        ExternalSettings.AddTo(hostBuilder.Configuration);
        hostBuilder.Logging.ClearProviders();
        hostBuilder.Logging.SetMinimumLevel(LogLevel.Warning);
        hostBuilder.Logging.AddSimpleConsole(o => o.SingleLine = true);

        ConfigureServices(hostBuilder.Services, hostBuilder.Configuration);

        using var host = hostBuilder.Build();

        return args[0] switch
        {
            "superadmin" => await HandleSuperadminAsync(host, args[1..]),
            "backup" => await HandleBackupAsync(host, args[1..]),
            "restore" => await HandleRestoreAsync(host, args[1..]),
            "test-connection" => await HandleTestConnectionAsync(args[1..]),
            "reencode-images" => await HandleReencodeImagesAsync(host, args[1..]),
            _ => Fail($"unknown cli command '{args[0]}'")
        };
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.Section));

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var db = sp.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            var cs = db.GetConnectionString();
            switch (db.Provider.ToUpperInvariant())
            {
                case "MSSQL":
                    options.UseSqlServer(cs, b => b.MigrationsAssembly("asERP.Persistence.MSSQL"));
                    break;
                case "POSTGRESQL":
                    options.UseNpgsql(cs, b => b.MigrationsAssembly("asERP.Persistence.PostgreSQL"));
                    break;
                case "SQLITE":
                    options.UseSqlite(cs, b => b.MigrationsAssembly("asERP.Persistence.SQLite"));
                    break;
                default:
                    throw new ArgumentException($"Unsupported database provider: {db.Provider}");
            }
        });

        // ApplicationDbContext takes ITenantContext as a constructor dependency; the
        // CLI runs without an HTTP request, so a fresh empty context is fine — query
        // filters fall back to "no tenant".
        services.AddScoped<ITenantContext, TenantContext>();

        services.Configure<BackupOptions>(configuration.GetSection(BackupOptions.Section));
        services.AddScoped<IDatabaseBackupService, DatabaseBackupService>();

        // Product-image storage, so the reencode-images maintenance command can rewrite files.
        services.Configure<FileStorageOptions>(configuration.GetSection(FileStorageOptions.Section));
        services.AddScoped<IProductImageStorage, ProductImageStorage>();

        services.AddDataProtection().SetApplicationName("asERP");

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }

    private static async Task<int> HandleSuperadminAsync(IHost host, string[] args)
    {
        if (args.Length == 0)
        {
            return Fail("'superadmin' requires a subcommand (create|update|delete|list).");
        }

        using var scope = host.Services.CreateScope();
        var users = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roles = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        return args[0] switch
        {
            "create" => await CreateAsync(users, roles),
            "update" => await UpdateAsync(users, args[1..]),
            "delete" => await DeleteAsync(users, args[1..]),
            "list" => await ListAsync(users),
            _ => Fail($"unknown superadmin subcommand '{args[0]}'.")
        };
    }

    private static async Task<int> HandleBackupAsync(IHost host, string[] args)
    {
        if (args.Length == 0)
        {
            return Fail("'backup' requires <targetFile>.");
        }

        using var scope = host.Services.CreateScope();
        var backupService = scope.ServiceProvider.GetRequiredService<IDatabaseBackupService>();

        var targetFile = args[0];
        if (string.IsNullOrEmpty(Path.GetExtension(targetFile)))
        {
            targetFile += backupService.BackupFileExtension;
        }

        try
        {
            await backupService.BackupAsync(targetFile);
        }
        catch (Exception ex)
        {
            return Fail($"backup failed: {ex.Message}");
        }

        Console.WriteLine($"Backup written to '{Path.GetFullPath(targetFile)}'.");
        return 0;
    }

    private static async Task<int> HandleRestoreAsync(IHost host, string[] args)
    {
        if (args.Length == 0)
        {
            return Fail("'restore' requires <sourceFile>.");
        }

        var sourceFile = args[0];
        if (!File.Exists(sourceFile))
        {
            return Fail($"backup file '{sourceFile}' does not exist.");
        }

        using var scope = host.Services.CreateScope();
        var backupService = scope.ServiceProvider.GetRequiredService<IDatabaseBackupService>();

        try
        {
            await backupService.RestoreAsync(sourceFile);
        }
        catch (Exception ex)
        {
            return Fail($"restore failed: {ex.Message}");
        }

        // Migrations only run forward: restoring an OLDER backup is the supported path (pending
        // migrations are applied on the next server start). A backup created by a NEWER asERP
        // version contains migration ids this binary does not know — warn loudly.
        try
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var knownMigrations = context.Database.GetMigrations().ToHashSet();
            var unknownMigrations = (await context.Database.GetAppliedMigrationsAsync())
                .Where(migration => !knownMigrations.Contains(migration))
                .ToList();
            if (unknownMigrations.Count > 0)
            {
                Console.Error.WriteLine(
                    $"warning: the restored database contains {unknownMigrations.Count} migration(s) unknown to this " +
                    "asERP version — the backup was created by a newer release. Upgrade asERP before starting the server.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"warning: could not verify the restored database's migration history: {ex.Message}");
        }

        Console.WriteLine("Restore completed. Pending migrations (if any) are applied on the next server start.");
        return 0;
    }

    // Validates candidate settings from the tray's settings dialog WITHOUT persisting them —
    // the provider/connection string are passed explicitly instead of read from configuration.
    private static async Task<int> HandleTestConnectionAsync(string[] args)
    {
        string? provider = null;
        string? connectionString = null;
        for (var i = 0; i < args.Length - 1; i++)
        {
            switch (args[i])
            {
                case "--provider":
                    provider = args[++i];
                    break;
                case "--connection-string":
                    connectionString = args[++i];
                    break;
            }
        }

        if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(connectionString))
        {
            return Fail("'test-connection' requires --provider <Sqlite|PostgreSQL|MSSQL> and --connection-string <cs>.");
        }

        try
        {
            switch (provider.ToUpperInvariant())
            {
                case "SQLITE":
                    await TestConnectionAsync(new SqliteConnection(connectionString));
                    break;
                case "MSSQL":
                    await TestConnectionAsync(new SqlConnection(connectionString));
                    break;
                case "POSTGRESQL":
                    await TestConnectionAsync(new NpgsqlConnection(connectionString));
                    break;
                default:
                    return Fail($"unsupported database provider '{provider}'.");
            }
        }
        catch (Exception ex)
        {
            return Fail($"connection failed: {ex.Message}");
        }

        Console.WriteLine("Connection successful.");
        return 0;
    }

    // Re-encodes every stored product image into the configured FileStorage format (e.g. PNG → WebP)
    // and updates the DB rows to match. Host-level maintenance: runs across all tenants. Idempotent —
    // images already in the target format are skipped, so it is safe to re-run and to resume after an abort.
    private static async Task<int> HandleReencodeImagesAsync(IHost host, string[] args)
    {
        var dryRun = args.Contains("--dry-run");
        var batchSize = 200;
        for (var i = 0; i < args.Length - 1; i++)
        {
            if (args[i] == "--batch" && int.TryParse(args[i + 1], out var parsed) && parsed > 0)
            {
                batchSize = parsed;
            }
        }

        using var scope = host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var storage = scope.ServiceProvider.GetRequiredService<IProductImageStorage>();

        // Bypass the tenant query filter — this is cross-tenant host maintenance (the CLI has no tenant).
        var baseQuery = db.Set<ProductImage>().IgnoreQueryFilters();

        var ids = await baseQuery.OrderBy(image => image.Id).Select(image => image.Id).ToListAsync();
        Console.WriteLine($"{ids.Count} product image row(s) found.");
        if (ids.Count == 0)
        {
            return 0;
        }

        if (dryRun)
        {
            var recordedBytes = await baseQuery.SumAsync(image => image.FileSizeBytes);
            Console.WriteLine(
                $"[dry-run] would re-encode up to {ids.Count} images ({FormatBytes(recordedBytes)} of originals recorded in the DB). " +
                "Already-converted images are skipped at run time. No files changed.");
            return 0;
        }

        long beforeBytes = 0, afterBytes = 0;
        int migrated = 0, skipped = 0, failed = 0, processed = 0;

        for (var offset = 0; offset < ids.Count; offset += batchSize)
        {
            var chunk = ids.Skip(offset).Take(batchSize).ToList();
            var images = await baseQuery.Where(image => chunk.Contains(image.Id)).ToListAsync();

            // Old files to remove *after* the batch is persisted (crash-safe ordering).
            var oldFiles = new List<(string Original, string Thumbnail)>();

            foreach (var image in images)
            {
                processed++;
                try
                {
                    var originalSizeBefore = image.FileSizeBytes;
                    var oldOriginal = image.RelativePath;
                    var oldThumbnail = image.ThumbnailPath;

                    var reencodedOriginal = await storage.ReencodeAsync(image.RelativePath);
                    var reencodedThumbnail = await storage.ReencodeAsync(image.ThumbnailPath);

                    if (reencodedOriginal is null && reencodedThumbnail is null)
                    {
                        skipped++;
                        continue;
                    }

                    if (reencodedOriginal is not null)
                    {
                        beforeBytes += originalSizeBefore;
                        afterBytes += reencodedOriginal.FileSizeBytes;
                        image.RelativePath = reencodedOriginal.RelativePath;
                        image.FileName = reencodedOriginal.FileName;
                        image.FileSizeBytes = reencodedOriginal.FileSizeBytes;
                        image.Width = reencodedOriginal.Width;
                        image.Height = reencodedOriginal.Height;
                    }

                    if (reencodedThumbnail is not null)
                    {
                        image.ThumbnailPath = reencodedThumbnail.RelativePath;
                    }

                    oldFiles.Add((
                        reencodedOriginal is not null ? oldOriginal : string.Empty,
                        reencodedThumbnail is not null ? oldThumbnail : string.Empty));
                    migrated++;
                }
                catch (Exception ex)
                {
                    failed++;
                    Console.Error.WriteLine($"warning: failed to re-encode image {image.Id}: {ex.Message}");
                }
            }

            await db.SaveChangesAsync();

            // New paths are persisted — now it is safe to delete the superseded originals.
            foreach (var (original, thumbnail) in oldFiles)
            {
                await storage.DeleteAsync(
                    string.IsNullOrEmpty(original) ? thumbnail : original,
                    string.IsNullOrEmpty(original) ? null : thumbnail);
            }

            Console.WriteLine($"  processed {processed}/{ids.Count} (migrated {migrated}, skipped {skipped}, failed {failed})");
        }

        Console.WriteLine($"Done. Migrated {migrated}, skipped {skipped}, failed {failed}.");
        if (beforeBytes > 0)
        {
            var percent = 100 - (afterBytes * 100.0 / beforeBytes);
            Console.WriteLine($"Originals: {FormatBytes(beforeBytes)} → {FormatBytes(afterBytes)} ({percent:F1}% smaller).");
        }

        return failed > 0 ? 1 : 0;
    }

    private static string FormatBytes(long bytes)
    {
        string[] units = ["B", "KB", "MB", "GB", "TB"];
        double value = bytes;
        var unit = 0;
        while (value >= 1024 && unit < units.Length - 1)
        {
            value /= 1024;
            unit++;
        }

        return $"{value:F1} {units[unit]}";
    }

    private static async Task TestConnectionAsync(System.Data.Common.DbConnection connection)
    {
        await using (connection)
        {
            await connection.OpenAsync();
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT 1";
            await command.ExecuteScalarAsync();
        }
    }

    private static async Task<int> CreateAsync(UserManager<ApplicationUser> users, RoleManager<IdentityRole> roles)
    {
        // Inputs are passed via env vars by cli.sh — keeps passwords out of argv
        // and out of any audit logs that capture command lines.
        var email = Environment.GetEnvironmentVariable("ASERP_CLI_EMAIL");
        var password = Environment.GetEnvironmentVariable("ASERP_CLI_PASSWORD");
        var firstname = Environment.GetEnvironmentVariable("ASERP_CLI_FIRSTNAME");
        var lastname = Environment.GetEnvironmentVariable("ASERP_CLI_LASTNAME");

        if (string.IsNullOrWhiteSpace(email))
        {
            return Fail("ASERP_CLI_EMAIL env var is required.");
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            return Fail("ASERP_CLI_PASSWORD env var is required.");
        }

        if (await users.FindByEmailAsync(email) is not null)
        {
            return Fail($"a user with email '{email}' already exists.");
        }

        foreach (var roleName in new[] { SuperadminRole, UserRole })
        {
            if (!await roles.RoleExistsAsync(roleName))
            {
                var roleResult = await roles.CreateAsync(new IdentityRole(roleName));
                if (!roleResult.Succeeded)
                {
                    return Fail($"failed to create role '{roleName}': {Describe(roleResult)}");
                }
            }
        }

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            Firstname = string.IsNullOrWhiteSpace(firstname) ? "Super" : firstname!,
            Lastname = string.IsNullOrWhiteSpace(lastname) ? "Admin" : lastname!
        };

        var create = await users.CreateAsync(user, password);
        if (!create.Succeeded)
        {
            return Fail($"could not create user: {Describe(create)}");
        }

        var assign = await users.AddToRoleAsync(user, SuperadminRole);
        if (!assign.Succeeded)
        {
            // Best-effort cleanup so we don't leave a half-configured account behind.
            await users.DeleteAsync(user);
            return Fail($"could not assign Superadmin role: {Describe(assign)}");
        }

        Console.WriteLine($"Superadmin '{email}' created.");
        return 0;
    }

    private static async Task<int> UpdateAsync(UserManager<ApplicationUser> users, string[] args)
    {
        if (args.Length == 0)
        {
            return Fail("'superadmin update' requires <email>.");
        }

        var email = args[0];
        var user = await users.FindByEmailAsync(email);
        if (user is null)
        {
            return Fail($"user '{email}' not found.");
        }

        var existingRoles = await users.GetRolesAsync(user);
        if (!existingRoles.Contains(SuperadminRole))
        {
            return Fail($"user '{email}' is not a Superadmin — refusing to update a regular user via this command.");
        }

        var newEmail = Environment.GetEnvironmentVariable("ASERP_CLI_NEW_EMAIL");
        var firstname = Environment.GetEnvironmentVariable("ASERP_CLI_FIRSTNAME");
        var lastname = Environment.GetEnvironmentVariable("ASERP_CLI_LASTNAME");
        var password = Environment.GetEnvironmentVariable("ASERP_CLI_PASSWORD");

        var changed = false;

        if (!string.IsNullOrWhiteSpace(newEmail) && !string.Equals(newEmail, user.Email, StringComparison.OrdinalIgnoreCase))
        {
            if (await users.FindByEmailAsync(newEmail) is not null)
            {
                return Fail($"a user with email '{newEmail}' already exists.");
            }

            var setEmail = await users.SetEmailAsync(user, newEmail);
            if (!setEmail.Succeeded)
            {
                return Fail($"could not update email: {Describe(setEmail)}");
            }
            var setUserName = await users.SetUserNameAsync(user, newEmail);
            if (!setUserName.Succeeded)
            {
                return Fail($"could not update username: {Describe(setUserName)}");
            }
            changed = true;
        }

        if (!string.IsNullOrWhiteSpace(firstname) && firstname != user.Firstname)
        {
            user.Firstname = firstname!;
            changed = true;
        }
        if (!string.IsNullOrWhiteSpace(lastname) && lastname != user.Lastname)
        {
            user.Lastname = lastname!;
            changed = true;
        }

        if (changed)
        {
            var update = await users.UpdateAsync(user);
            if (!update.Succeeded)
            {
                return Fail($"could not update user: {Describe(update)}");
            }
        }

        if (!string.IsNullOrWhiteSpace(password))
        {
            var token = await users.GeneratePasswordResetTokenAsync(user);
            var reset = await users.ResetPasswordAsync(user, token, password);
            if (!reset.Succeeded)
            {
                return Fail($"could not update password: {Describe(reset)}");
            }
            changed = true;
        }

        if (!changed)
        {
            Console.WriteLine($"Superadmin '{email}' — nothing to update.");
            return 0;
        }

        Console.WriteLine($"Superadmin '{user.Email}' updated.");
        return 0;
    }

    private static async Task<int> DeleteAsync(UserManager<ApplicationUser> users, string[] args)
    {
        if (args.Length == 0)
        {
            return Fail("'superadmin delete' requires <email>.");
        }

        var email = args[0];
        var user = await users.FindByEmailAsync(email);
        if (user is null)
        {
            return Fail($"user '{email}' not found.");
        }

        var roles = await users.GetRolesAsync(user);
        if (!roles.Contains(SuperadminRole))
        {
            return Fail($"user '{email}' is not a Superadmin — refusing to delete a regular user via this command.");
        }

        var result = await users.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return Fail($"could not delete user: {Describe(result)}");
        }

        Console.WriteLine($"Superadmin '{email}' deleted.");
        return 0;
    }

    // Emits one JSON object per line (JSONL) so callers — e.g. the tray's superadmin
    // window — can parse each row without the human-readable log lines the other
    // subcommands print interfering.
    private static async Task<int> ListAsync(UserManager<ApplicationUser> users)
    {
        var superadmins = await users.GetUsersInRoleAsync(SuperadminRole);
        foreach (var user in superadmins.OrderBy(u => u.Email, StringComparer.OrdinalIgnoreCase))
        {
            var line = JsonSerializer.Serialize(new
            {
                id = user.Id,
                email = user.Email,
                firstname = user.Firstname,
                lastname = user.Lastname
            });
            Console.WriteLine(line);
        }

        return 0;
    }

    private static string Describe(IdentityResult result) =>
        string.Join("; ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));

    private static int Fail(string message)
    {
        Console.Error.WriteLine($"error: {message}");
        return 1;
    }

    private static void PrintHelp()
    {
        Console.Error.WriteLine("usage: dotnet asERP.Server.dll cli <command> [...]");
        Console.Error.WriteLine("  superadmin create           inputs via env: ASERP_CLI_EMAIL, ASERP_CLI_PASSWORD,");
        Console.Error.WriteLine("                              optional ASERP_CLI_FIRSTNAME, ASERP_CLI_LASTNAME");
        Console.Error.WriteLine("  superadmin update <email>   update a Superadmin user; optional env:");
        Console.Error.WriteLine("                              ASERP_CLI_NEW_EMAIL, ASERP_CLI_FIRSTNAME,");
        Console.Error.WriteLine("                              ASERP_CLI_LASTNAME, ASERP_CLI_PASSWORD");
        Console.Error.WriteLine("  superadmin delete <email>   delete a Superadmin user by email");
        Console.Error.WriteLine("  superadmin list             list Superadmin users as JSON (one object per line)");
        Console.Error.WriteLine("  backup <targetFile>         write a provider-native database backup");
        Console.Error.WriteLine("                              (.db for SQLite, .bak for MSSQL, .dump for PostgreSQL)");
        Console.Error.WriteLine("  restore <sourceFile>        overwrite the database from a backup file;");
        Console.Error.WriteLine("                              stop the server/service before restoring");
        Console.Error.WriteLine("  test-connection --provider <Sqlite|PostgreSQL|MSSQL> --connection-string <cs>");
        Console.Error.WriteLine("                              validate database settings without persisting them");
        Console.Error.WriteLine("  reencode-images [--dry-run] [--batch <n>]");
        Console.Error.WriteLine("                              re-encode stored product images into the configured");
        Console.Error.WriteLine("                              FileStorage format (e.g. PNG → WebP) and update the DB;");
        Console.Error.WriteLine("                              idempotent and resumable (default batch 200)");
    }
}
