namespace asERP.Domain.Interfaces;

/// <summary>
/// Shared shape of shop-domain input models — implemented by the input DTO (server) and any
/// client edit model so both validate against the same base rules.
/// </summary>
public interface IShopDomainInputModel
{
    Guid SalesChannelId { get; }
    string Host { get; }
    int Port { get; }
    bool IsPrimary { get; }
    bool RedirectToPrimary { get; }
}
