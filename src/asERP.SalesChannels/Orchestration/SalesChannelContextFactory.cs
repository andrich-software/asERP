using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Abstractions;

namespace asERP.SalesChannels.Orchestration;

/// <summary>
/// Builds a per-run <see cref="SalesChannelContext"/> from a <see cref="SalesChannel"/> entity:
/// decrypts credentials, requests the matching typed HttpClient from the factory, and pre-points
/// the client at the channel's base URL.
/// </summary>
public sealed class SalesChannelContextFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ICredentialEncryptor _encryptor;

    public SalesChannelContextFactory(IHttpClientFactory httpClientFactory, ICredentialEncryptor encryptor)
    {
        _httpClientFactory = httpClientFactory;
        _encryptor = encryptor;
    }

    public SalesChannelContext Create(
        SalesChannel salesChannel,
        ChannelSyncRun syncRun,
        CancellationToken cancellationToken,
        DateTime? incrementalSince = null,
        Func<int, int, CancellationToken, Task>? reportProgress = null,
        SalesChannelOperationState? operationState = null,
        bool credentialsArePlaintext = false)
    {
        var clientName = HttpClientNameFor(salesChannel.Type);
        var httpClient = _httpClientFactory.CreateClient(clientName);
        httpClient.Timeout = TimeSpan.FromSeconds(60);

        // Credentials on an entity materialised from the database are already decrypted by the
        // EncryptedStringConverter when EF reads them, so we just pass them through. We re-decrypt
        // only as a guard against legacy plaintext rows (the encryptor passes plaintext through
        // unchanged). Callers that build a transient channel from request input must pass
        // credentialsArePlaintext: running caller-supplied values through Decrypt would make such an
        // endpoint a decryption oracle for the key ring — submit a ciphertext read out of the
        // database, get the plaintext delivered to the caller-chosen URL.
        string Materialize(string? credential) => credentialsArePlaintext
            ? credential ?? string.Empty
            : _encryptor.Decrypt(credential ?? string.Empty);

        return new SalesChannelContext
        {
            SalesChannel = salesChannel,
            Password = Materialize(salesChannel.Password),
            AccessToken = Materialize(salesChannel.AccessToken),
            RefreshToken = Materialize(salesChannel.RefreshToken),
            HttpClient = httpClient,
            SyncRun = syncRun,
            OperationState = operationState,
            TenantId = salesChannel.TenantId,
            IncrementalSince = incrementalSince,
            ReportProgressAsync = reportProgress,
            CancellationToken = cancellationToken,
        };
    }

    public static string HttpClientNameFor(SalesChannelType type) => type switch
    {
        SalesChannelType.Shopware6 => "shopware6",
        SalesChannelType.WooCommerce => "woocommerce",
        SalesChannelType.eBay => "ebay",
        SalesChannelType.Amazon => "amazon",
        _ => "default",
    };
}
