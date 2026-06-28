using asToolkit.Domain.Entities.Common;

namespace asToolkit.Domain.Entities;

public class CustomerSalesChannel : BaseEntity, IBaseEntity
{
    public required Guid CustomerId { get; set; }
    public required Guid SalesChannelId { get; set; }
    public required string RemoteCustomerId { get; set; } = string.Empty;
}