using asERP.SalesChannels.Models;

namespace asERP.SalesChannels.Contracts;

public interface IProductImportRepository
{
    Task ImportOrUpdateFromSalesChannel(Guid salesChannelId, SalesChannelImportProduct importProduct);
}
