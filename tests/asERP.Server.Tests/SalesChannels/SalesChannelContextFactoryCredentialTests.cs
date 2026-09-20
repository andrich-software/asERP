using System.Net.Http;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Orchestration;
using asERP.Server.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Credential handling in <see cref="SalesChannelContextFactory"/>: values read from the database go
/// through Decrypt (legacy-plaintext guard), while credentials a caller typed into the create wizard
/// must not — otherwise the draft connection test would decrypt any ciphertext handed to it and send
/// the plaintext to the caller-supplied URL.
/// </summary>
public class SalesChannelContextFactoryCredentialTests
{
    private static DataProtectionCredentialEncryptor CreateEncryptor()
    {
        var services = new ServiceCollection();
        services.AddDataProtection().SetApplicationName("test-app");
        var provider = services.BuildServiceProvider();
        return new DataProtectionCredentialEncryptor(provider.GetRequiredService<IDataProtectionProvider>());
    }

    private static SalesChannel Channel(string password, string? accessToken = null, string? refreshToken = null) => new()
    {
        Id = Guid.NewGuid(),
        Type = SalesChannelType.Shopware6,
        Name = "connection-test",
        Url = "https://shop.example.com",
        Username = "user",
        Password = password,
        AccessToken = accessToken,
        RefreshToken = refreshToken,
    };

    private static ChannelSyncRun Run() => new()
    {
        Id = Guid.NewGuid(),
        Operation = ChannelSyncOperation.ImportProducts,
        TriggerSource = ChannelSyncTriggerSource.Manual,
        Status = ChannelSyncRunStatus.Success,
        StartedAt = DateTime.UtcNow,
        CorrelationId = Guid.NewGuid(),
    };

    [Fact]
    public void PlaintextCredentials_AreNotDecrypted()
    {
        var encryptor = CreateEncryptor();
        var factory = new SalesChannelContextFactory(new StubHttpClientFactory(), encryptor);
        var stolenCiphertext = encryptor.Encrypt("another-tenants-secret");

        var context = factory.Create(
            Channel(stolenCiphertext, stolenCiphertext, stolenCiphertext), Run(), CancellationToken.None,
            credentialsArePlaintext: true);

        Assert.Equal(stolenCiphertext, context.Password);
        Assert.Equal(stolenCiphertext, context.AccessToken);
        Assert.Equal(stolenCiphertext, context.RefreshToken);
    }

    [Fact]
    public void PlaintextCredentials_PassRealPasswordsThroughUnchanged()
    {
        var factory = new SalesChannelContextFactory(new StubHttpClientFactory(), CreateEncryptor());

        var context = factory.Create(
            Channel("shop-api-secret"), Run(), CancellationToken.None, credentialsArePlaintext: true);

        Assert.Equal("shop-api-secret", context.Password);
        Assert.Equal(string.Empty, context.AccessToken);
    }

    [Fact]
    public void StoredCredentials_AreStillDecrypted()
    {
        var encryptor = CreateEncryptor();
        var factory = new SalesChannelContextFactory(new StubHttpClientFactory(), encryptor);
        var stored = encryptor.Encrypt("stored-secret");

        var context = factory.Create(Channel(stored), Run(), CancellationToken.None);

        Assert.Equal("stored-secret", context.Password);
    }

    [Fact]
    public void StoredCredentials_StillPassLegacyPlaintextThrough()
    {
        var factory = new SalesChannelContextFactory(new StubHttpClientFactory(), CreateEncryptor());

        var context = factory.Create(Channel("legacy-plaintext"), Run(), CancellationToken.None);

        Assert.Equal("legacy-plaintext", context.Password);
    }

    private sealed class StubHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new();
    }
}
