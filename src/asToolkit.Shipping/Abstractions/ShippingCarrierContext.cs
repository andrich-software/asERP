using asToolkit.Domain.Entities;

namespace asToolkit.Shipping.Abstractions;

/// <summary>
/// Everything a connector call needs: the provider row plus its decrypted credentials.
/// Built by <c>ShippingCarrierContextFactory</c> — connectors never decrypt themselves.
/// </summary>
public sealed class ShippingCarrierContext
{
    public required ShippingProvider Provider { get; init; }

    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string ApiKey { get; init; }
    public required string ApiSecret { get; init; }
    public string? AccountNumber { get; init; }

    public bool UseSandbox { get; init; }
    public Guid? TenantId { get; init; }

    public CancellationToken CancellationToken { get; init; }
}
