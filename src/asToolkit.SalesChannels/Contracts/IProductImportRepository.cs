using asToolkit.SalesChannels.Models;

namespace asToolkit.SalesChannels.Contracts;

public interface IProductImportRepository
{
    Task ImportOrUpdateFromSalesChannel(Guid salesChannelId, SalesChannelImportProduct importProduct);
}
