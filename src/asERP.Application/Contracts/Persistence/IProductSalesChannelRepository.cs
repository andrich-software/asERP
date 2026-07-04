using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IProductSalesChannelRepository : IGenericRepository<ProductSalesChannel>
{
    Task<ProductSalesChannel?> GetByRemoteProductIdAsync(string remoteProductId, Guid salesChannelId = default);
}
