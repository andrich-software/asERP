using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

public class CustomerSalesChannel : BaseEntity, IBaseEntity
{
    public required Guid CustomerId { get; set; }
    public required Guid SalesChannelId { get; set; }
    public required string RemoteCustomerId { get; set; } = string.Empty;
}