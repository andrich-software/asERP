using maERP.Domain.Entities;

namespace maERP.Application.Contracts.Persistence;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer?> GetCustomerWithDetails(Guid id);
    Task<Customer?> GetByCustomerIdAsync(int customerId);
    Task<Customer?> GetCustomerByEmailAsync(string email);
    Task<Customer?> GetCustomerByRemoteCustomerIdAsync(Guid salesChannelId, string remoteCustomerId);
    Task AddCustomerToSalesChannelAsync(Guid customerId, Guid salesChannelId, string remoteCustomerId);
    Task<ICollection<CustomerAddress>> GetCustomerAddressByCustomerIdAsync(Guid customerId);
    Task<CustomerAddress> AddCustomerAddressAsync(CustomerAddress customerAddress);

    /// <summary>Highest <see cref="Customer.CustomerId"/> in the current tenant (0 if none). Bulk importers
    /// seed an in-memory counter from this once instead of issuing a MAX scan per inserted row.</summary>
    Task<int> GetMaxCustomerIdAsync();
}