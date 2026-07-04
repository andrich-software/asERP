using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Shipping.Abstractions;

namespace asERP.Shipping.Orchestration;

/// <summary>
/// Builds a <see cref="ShippingCarrierContext"/> with decrypted credentials. The decryptor
/// passes through legacy plaintext values, so pre-encryption rows keep working.
/// </summary>
public sealed class ShippingCarrierContextFactory
{
    private readonly ICredentialEncryptor _encryptor;

    public ShippingCarrierContextFactory(ICredentialEncryptor encryptor)
    {
        _encryptor = encryptor;
    }

    public ShippingCarrierContext Create(ShippingProvider provider, CancellationToken cancellationToken)
    {
        return new ShippingCarrierContext
        {
            Provider = provider,
            Username = provider.Username,
            Password = _encryptor.Decrypt(provider.Password),
            ApiKey = _encryptor.Decrypt(provider.ApiKey ?? string.Empty),
            ApiSecret = _encryptor.Decrypt(provider.ApiSecret ?? string.Empty),
            AccountNumber = provider.AccountNumber,
            UseSandbox = provider.UseSandbox,
            TenantId = provider.TenantId,
            CancellationToken = cancellationToken
        };
    }
}
