namespace asERP.Domain.Dtos.ShopDomain;

public class ShopDomainListDto
{
    public Guid Id { get; set; }
    public Guid SalesChannelId { get; set; }
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool IsPrimary { get; set; }
    public bool RedirectToPrimary { get; set; }
}
