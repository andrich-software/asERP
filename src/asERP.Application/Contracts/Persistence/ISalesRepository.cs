using asERP.Domain.Entities;
using asERP.Domain.Enums;

namespace asERP.Application.Contracts.Persistence;

public interface ISalesRepository : IGenericRepository<Sales>
{
    Task<Sales?> GetWithDetailsAsync(Guid id);
    Task<Sales?> GetByRemoteSalesIdAsync(Guid salesChannelId, string remoteSalesId);
    Task<List<SalesHistory>> GetSalesHistoryAsync(Guid salesId);

    /// <summary>History entries stamped with the given shipment id, newest first — feeds the
    /// per-shipment tracking timeline.</summary>
    Task<List<SalesHistory>> GetShippingHistoryAsync(Guid shippingId);
    Task AddSalesHistoryAsync(SalesHistory entry);
    Task<bool> CanCreateInvoice(Guid salesId);
    Task<int> GetNextSalesIdAsync();
    Task<int> GetMaxSalesIdAsync();
}
