using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class CustomerSalesChannelConfiguration : IEntityTypeConfiguration<CustomerSalesChannel>
{
    public void Configure(EntityTypeBuilder<CustomerSalesChannel> builder)
    {
        // Hot path: the sales import resolves the customer of each order via
        // GetCustomerByRemoteCustomerIdAsync (WHERE SalesChannelId AND RemoteCustomerId). Without an
        // index this seq-scans the whole (growing) link table on every imported order.
        builder.HasIndex(e => new { e.SalesChannelId, e.RemoteCustomerId });
    }
}
