using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {

    }

    public async Task<Customer?> GetCustomerWithDetails(Guid id)
    {
        // Tenant isolation via the global query filter.
        return await Context.Customer
            .Where(x => x.Id == id)
            .Include(x => x.CustomerAddresses)
            .Include(x => x.Saless)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetByCustomerIdAsync(int customerId)
    {
        // Tenant isolation via the global query filter.
        return await Context.Customer
            .Where(x => x.CustomerId == customerId)
            .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        // Tenant isolation via the global query filter.
        return await Context.Customer
            .Where(x => x.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetCustomerByRemoteCustomerIdAsync(Guid salesChannelId, string remoteCustomerId)
    {
        // Tenant isolation via the global query filter.
        return await Context.Customer
            .Where(x => x.CustomerSalesChannels!.Any(y => y.SalesChannelId == salesChannelId && y.RemoteCustomerId == remoteCustomerId))
            .FirstOrDefaultAsync();
    }

    public async Task AddCustomerToSalesChannelAsync(Guid customerId, Guid salesChannelId, string remoteCustomerId)
    {
        var customerSalesChannel = new CustomerSalesChannel
        {
            CustomerId = customerId,
            SalesChannelId = salesChannelId,
            RemoteCustomerId = remoteCustomerId
        };

        await Context.CustomerSalesChannel.AddAsync(customerSalesChannel);
        await Context.SaveChangesAsync();
    }

    public async Task<ICollection<CustomerAddress>> GetCustomerAddressByCustomerIdAsync(Guid customerId)
    {
        // Tenant isolation via the global query filter.
        return await Context.CustomerAddress
            .Where(x => x.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<CustomerAddress> AddCustomerAddressAsync(CustomerAddress customerAddress)
    {
        await Context.CustomerAddress.AddAsync(customerAddress);
        await Context.SaveChangesAsync();
        return customerAddress;
    }

    public async Task<int> GetMaxCustomerIdAsync()
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.Customer.AsQueryable();
        if (currentTenantId.HasValue)
        {
            query = query.Where(c => c.TenantId == currentTenantId.Value);
        }

        return await query.MaxAsync(c => (int?)c.CustomerId) ?? 0;
    }

    public new async Task<Guid> CreateAsync(Customer entity)
    {
        // Auto-generate the per-tenant CustomerId only when the caller did not pre-assign one. Bulk
        // importers seed an in-memory counter once (via GetMaxCustomerIdAsync) and set CustomerId
        // themselves, which avoids a MAX scan over the growing customer table on every inserted row.
        if (entity.CustomerId == 0)
        {
            entity.CustomerId = await GetMaxCustomerIdAsync() + 1;
        }

        return await base.CreateAsync(entity);
    }

}
