using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.ShopDomain;

/// <summary>
/// Input for creating and updating a shop host binding. The host is normalized server-side
/// (lowercase, punycode, no scheme/port); Port 0 means "any port" — the normal case behind
/// Cloudflare/reverse proxies.
/// </summary>
public class ShopDomainInputDto : IShopDomainInputModel
{
    public Guid Id { get; set; }
    public Guid SalesChannelId { get; set; }
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool IsPrimary { get; set; }
    public bool RedirectToPrimary { get; set; } = true;
}
