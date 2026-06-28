using asToolkit.Domain.Entities;
using asToolkit.SalesChannels.Models;

namespace asToolkit.SalesChannels.Contracts;

public interface ISalesImportRepository
{
    Task ImportOrUpdateFromSalesChannel(SalesChannel salesChannel, SalesChannelImportSales importSales);
}