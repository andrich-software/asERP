using asERP.Domain.Entities;
using asERP.SalesChannels.Models;

namespace asERP.SalesChannels.Contracts;

public interface ISalesImportRepository
{
    Task ImportOrUpdateFromSalesChannel(SalesChannel salesChannel, SalesChannelImportSales importSales);
}