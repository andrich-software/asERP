using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;

namespace asToolkit.Application.Contracts.Persistence;

public interface ISalesRepository : IGenericRepository<Sales>
{
    Task<Sales?> GetWithDetailsAsync(Guid id);
    Task<Sales?> GetByRemoteSalesIdAsync(Guid salesChannelId, string remoteSalesId);
    Task<List<SalesHistory>> GetSalesHistoryAsync(Guid salesId);
    Task<bool> CanCreateInvoice(Guid salesId);
    Task<int> GetNextSalesIdAsync();
    Task<int> GetMaxSalesIdAsync();
}
