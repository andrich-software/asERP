using asToolkit.Domain.Entities;
using asToolkit.SalesChannels.Models;

namespace asToolkit.SalesChannels.Contracts;

public interface ICustomerImportRepository
{
    Task ImportOrUpdateFromSalesChannel(SalesChannel salesChannel, SalesChannelImportCustomer importCustomer);
}