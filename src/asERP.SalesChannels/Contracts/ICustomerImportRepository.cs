using asERP.Domain.Entities;
using asERP.SalesChannels.Models;

namespace asERP.SalesChannels.Contracts;

public interface ICustomerImportRepository
{
    Task ImportOrUpdateFromSalesChannel(SalesChannel salesChannel, SalesChannelImportCustomer importCustomer);
}