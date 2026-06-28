using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Identity.Services;
using asToolkit.Persistence.Configurations.Options;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace asToolkit.Server.Cli;

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
        hostBuilder.Logging.ClearProviders();
        hostBuilder.Logging.SetMinimumLevel(LogLevel.Warning);
        hostBuilder.Logging.AddSimpleConsole(o => o.SingleLine = true);

        ConfigureServices(hostBuilder.Services, hostBuilder.Configuration);

        using var host = hostBuilder.Build();

        return args[0] switch
        {
            "superadmin" => await HandleSuperadminAsync(host, args[1..]),
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
                    options.UseSqlServer(cs, b => b.MigrationsAssembly("asToolkit.Persistence.MSSQL"));
                    break;
                case "POSTGRESQL":
                    options.UseNpgsql(cs, b => b.MigrationsAssembly("asToolkit.Persistence.PostgreSQL"));
                    break;
                case "SQLITE":
                    options.UseSqlite(cs, b => b.MigrationsAssembly("asToolkit.Persistence.SQLite"));
                    break;
                default:
                    throw new ArgumentException($"Unsupported database provider: {db.Provider}");
            }
        });

        // ApplicationDbContext takes ITenantContext as a constructor dependency; the
        // CLI runs without an HTTP request, so a fresh empty context is fine — query
        // filters fall back to "no tenant".
        services.AddScoped<ITenantContext, TenantContext>();

        services.AddDataProtection().SetApplicationName("asToolkit");

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }

    private static async Task<int> HandleSuperadminAsync(IHost host, string[] args)
    {
        if (args.Length == 0)
        {
            return Fail("'superadmin' requires a subcommand (create|delete).");
        }

        using var scope = host.Services.CreateScope();
        var users = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roles = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        return args[0] switch
        {
            "create" => await CreateAsync(users, roles),
            "update" => await UpdateAsync(users, args[1..]),
            "delete" => await DeleteAsync(users, args[1..]),
            _ => Fail($"unknown superadmin subcommand '{args[0]}'.")
        };
    }

    private static async Task<int> CreateAsync(UserManager<ApplicationUser> users, RoleManager<IdentityRole> roles)
    {
        // Inputs are passed via env vars by cli.sh — keeps passwords out of argv
        // and out of any audit logs that capture command lines.
        var email = Environment.GetEnvironmentVariable("ASTOOLKIT_CLI_EMAIL");
        var password = Environment.GetEnvironmentVariable("ASTOOLKIT_CLI_PASSWORD");
        var firstname = Environment.GetEnvironmentVariable("ASTOOLKIT_CLI_FIRSTNAME");
        var lastname = Environment.GetEnvironmentVariable("ASTOOLKIT_CLI_LASTNAME");

        if (string.IsNullOrWhiteSpace(email))
        {
            return Fail("ASTOOLKIT_CLI_EMAIL env var is required.");
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            return Fail("ASTOOLKIT_CLI_PASSWORD env var is required.");
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

        var newEmail = Environment.GetEnvironmentVariable("ASTOOLKIT_CLI_NEW_EMAIL");
        var firstname = Environment.GetEnvironmentVariable("ASTOOLKIT_CLI_FIRSTNAME");
        var lastname = Environment.GetEnvironmentVariable("ASTOOLKIT_CLI_LASTNAME");
        var password = Environment.GetEnvironmentVariable("ASTOOLKIT_CLI_PASSWORD");

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

    private static string Describe(IdentityResult result) =>
        string.Join("; ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));

    private static int Fail(string message)
    {
        Console.Error.WriteLine($"error: {message}");
        return 1;
    }

    private static void PrintHelp()
    {
        Console.Error.WriteLine("usage: dotnet asToolkit.Server.dll cli <command> [...]");
        Console.Error.WriteLine("  superadmin create           inputs via env: ASTOOLKIT_CLI_EMAIL, ASTOOLKIT_CLI_PASSWORD,");
        Console.Error.WriteLine("                              optional ASTOOLKIT_CLI_FIRSTNAME, ASTOOLKIT_CLI_LASTNAME");
        Console.Error.WriteLine("  superadmin update <email>   update a Superadmin user; optional env:");
        Console.Error.WriteLine("                              ASTOOLKIT_CLI_NEW_EMAIL, ASTOOLKIT_CLI_FIRSTNAME,");
        Console.Error.WriteLine("                              ASTOOLKIT_CLI_LASTNAME, ASTOOLKIT_CLI_PASSWORD");
        Console.Error.WriteLine("  superadmin delete <email>   delete a Superadmin user by email");
    }
}
