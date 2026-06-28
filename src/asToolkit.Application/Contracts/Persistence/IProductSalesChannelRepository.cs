using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IProductSalesChannelRepository : IGenericRepository<ProductSalesChannel>
{
    Task<ProductSalesChannel?> GetByRemoteProductIdAsync(string remoteProductId, Guid salesChannelId = default);
}
