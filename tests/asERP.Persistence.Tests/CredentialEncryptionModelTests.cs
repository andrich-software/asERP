using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.Configurations.Options;
using asERP.Persistence.DatabaseContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace asERP.Persistence.Tests;

/// <summary>
/// Pins at-rest credential encryption against the silent degradation to the no-op encryptor: EF caches
/// one model per DbContext CLR type, and the credential value converters capture the encryptor of the
/// context that happened to build that model first (in production: the bootstrap service provider in
/// Program.cs, which had no ICredentialEncryptor - so every credential was written in cleartext).
/// </summary>
public class CredentialEncryptionModelTests
{
    private static readonly Guid TestTenantId = new("11111111-1111-1111-1111-111111111111");

    // A real relational provider - the credential value converters must survive a full round trip
    // through an actual column, not just the InMemory store.
    private static DbContextOptions<ApplicationDbContext> CreateOptions(SqliteConnection connection)
        => new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
            .ReplaceService<IModelCacheKeyFactory, CredentialEncryptorModelCacheKeyFactory>()
            .Options;

    private static SalesChannel NewSalesChannel(string name, string password)
        => new() { Id = Guid.NewGuid(), Name = name, Password = password, TenantId = TestTenantId };

    private static ShippingProvider NewShippingProvider(Guid id, string configJson)
        => new()
        {
            Id = id,
            Name = "DHL",
            Type = ShippingProviderType.Dhl,
            Username = "dhl-user",
            Password = "dhl-password",
            AdditionalConfigJson = configJson,
            TenantId = TestTenantId
        };

    [Fact]
    public async Task CredentialConverter_EncryptsWithTheContextsOwnEncryptor_AfterAContextWithoutOneBuiltTheModel()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var options = CreateOptions(connection);

        // First context of the process has no encryptor (the bootstrap provider case) and builds a model
        // whose converters are the identity function.
        await using (var withoutEncryptor = new ApplicationDbContext(options, new FixedTenantContext()))
        {
            await withoutEncryptor.Database.EnsureCreatedAsync();
            await withoutEncryptor.SalesChannel.AddAsync(NewSalesChannel("bootstrap", "bootstrap-secret"));
            await withoutEncryptor.SaveChangesAsync();
        }

        var encryptor = new ReversingEncryptor();
        var channel = NewSalesChannel("shopware", "shopware-secret");
        await using (var withEncryptor = new ApplicationDbContext(options, new FixedTenantContext(), encryptor))
        {
            await withEncryptor.SalesChannel.AddAsync(channel);
            await withEncryptor.SaveChangesAsync();
        }

        // A context without an encryptor sees the stored column verbatim: it must be ciphertext.
        await using var stored = new ApplicationDbContext(options, new FixedTenantContext());
        var storedChannel = await stored.SalesChannel.AsNoTracking().FirstAsync(c => c.Id == channel.Id);
        Assert.NotEqual("shopware-secret", storedChannel.Password);
        Assert.Equal(ReversingEncryptor.Transform("shopware-secret"), storedChannel.Password);

        // The encrypting context still round-trips its own value.
        await using var reread = new ApplicationDbContext(options, new FixedTenantContext(), encryptor);
        var rereadChannel = await reread.SalesChannel.AsNoTracking().FirstAsync(c => c.Id == channel.Id);
        Assert.Equal("shopware-secret", rereadChannel.Password);
    }

    [Fact]
    public async Task ShippingProviderConfigBlob_IsStoredAsCiphertext_AndRoundTrips()
    {
        // The carrier config blob carries a live credential (DHL TrackingApiKey), so it must go
        // through the same converter as the Password/ApiKey/ApiSecret columns next to it.
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var options = CreateOptions(connection);
        var encryptor = new LegacyTolerantEncryptor();
        var providerId = Guid.NewGuid();
        const string config = """{"Procedure":"01","TrackingApiKey":"live-dhl-tracking-key"}""";

        await using (var withEncryptor = new ApplicationDbContext(options, new FixedTenantContext(), encryptor))
        {
            await withEncryptor.Database.EnsureCreatedAsync();
            await withEncryptor.ShippingProvider.AddAsync(NewShippingProvider(providerId, config));
            await withEncryptor.SaveChangesAsync();
        }

        await using (var stored = new ApplicationDbContext(options, new FixedTenantContext()))
        {
            var row = await stored.ShippingProvider.AsNoTracking().FirstAsync(p => p.Id == providerId);
            Assert.DoesNotContain("live-dhl-tracking-key", row.AdditionalConfigJson);
            Assert.Equal(LegacyTolerantEncryptor.Transform(config), row.AdditionalConfigJson);
        }

        await using var reread = new ApplicationDbContext(options, new FixedTenantContext(), encryptor);
        var provider = await reread.ShippingProvider.AsNoTracking().FirstAsync(p => p.Id == providerId);
        Assert.Equal(config, provider.AdditionalConfigJson);
    }

    [Fact]
    public async Task ShippingProviderConfigBlob_LegacyCleartextRow_IsReadableAndReEncryptedOnNextSave()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var options = CreateOptions(connection);
        var providerId = Guid.NewGuid();
        const string config = """{"TrackingApiKey":"written-before-encryption-was-on"}""";
        const string RotatedConfig = """{"TrackingApiKey":"rotated-after-encryption-was-on"}""";

        await using (var withoutEncryptor = new ApplicationDbContext(options, new FixedTenantContext()))
        {
            await withoutEncryptor.Database.EnsureCreatedAsync();
            await withoutEncryptor.ShippingProvider.AddAsync(NewShippingProvider(providerId, config));
            await withoutEncryptor.SaveChangesAsync();
        }

        var encryptor = new LegacyTolerantEncryptor();
        await using (var withEncryptor = new ApplicationDbContext(options, new FixedTenantContext(), encryptor))
        {
            var provider = await withEncryptor.ShippingProvider.FirstAsync(p => p.Id == providerId);
            Assert.Equal(config, provider.AdditionalConfigJson);

            provider.AdditionalConfigJson = RotatedConfig;
            await withEncryptor.SaveChangesAsync();
        }

        await using var stored = new ApplicationDbContext(options, new FixedTenantContext());
        var row = await stored.ShippingProvider.AsNoTracking().FirstAsync(p => p.Id == providerId);
        Assert.Equal(LegacyTolerantEncryptor.Transform(RotatedConfig), row.AdditionalConfigJson);
    }

    [Fact]
    public void AddPersistenceServices_WithoutCredentialEncryptor_FailsClosed()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.Configure<DatabaseOptions>(o =>
        {
            o.Provider = "SQLITE";
            o.ConnectionString = "Data Source=:memory:";
        });
        services.AddPersistenceServices();
        using var provider = services.BuildServiceProvider();

        var ex = Assert.Throws<InvalidOperationException>(
            () => provider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
        Assert.Contains("ICredentialEncryptor", ex.Message);
    }

    // A fixed, shared tenant so every context over the same store agrees on ownership (SaveChangesAsync
    // refuses tenant-scoped entities without an active tenant context).
    private sealed class FixedTenantContext : ITenantContext
    {
        public Guid? GetCurrentTenantId() => TestTenantId;
        public void SetCurrentTenantId(Guid? tenantId) { }
        public bool HasTenant() => true;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => new[] { TestTenantId };
        public void SetAssignedTenantIds(IEnumerable<Guid> tenantIds) { }
        public bool IsAssignedToTenant(Guid tenantId) => tenantId == TestTenantId;
    }

    /// <summary>Deterministic stand-in for the DataProtection encryptor - reversing is its own inverse.</summary>
    private sealed class ReversingEncryptor : ICredentialEncryptor
    {
        public string Encrypt(string plaintext) => Transform(plaintext);
        public string Decrypt(string ciphertext) => Transform(ciphertext);

        public static string Transform(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value ?? string.Empty;
            }

            var chars = value.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }

    /// <summary>
    /// Mirrors the production encryptor's tolerance for rows written before encryption was rolled
    /// out: Decrypt returns anything it did not encrypt itself unchanged.
    /// </summary>
    private sealed class LegacyTolerantEncryptor : ICredentialEncryptor
    {
        private const string Prefix = "enc:";

        public string Encrypt(string plaintext)
            => string.IsNullOrEmpty(plaintext) ? plaintext ?? string.Empty : Transform(plaintext);

        public string Decrypt(string ciphertext)
            => ciphertext?.StartsWith(Prefix, StringComparison.Ordinal) == true
                ? Reverse(ciphertext[Prefix.Length..])
                : ciphertext ?? string.Empty;

        public static string Transform(string value) => Prefix + Reverse(value);

        private static string Reverse(string value)
        {
            var chars = value.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
