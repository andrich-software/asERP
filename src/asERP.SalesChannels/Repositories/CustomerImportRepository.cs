using asERP.Application.Contracts.Persistence;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Models;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Repositories;

public class CustomerImportRepository : ICustomerImportRepository
{
    private readonly ILogger<CustomerImportRepository> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICountryRepository _countryRepository;

    // Per-run country cache (repository is scoped): all countries loaded once instead of a SELECT per
    // address. Only ids/names are consumed, so entries surviving a tracker trim are harmless.
    private Dictionary<string, Country>? _countryCache;

    // Process-wide id allocator for the per-tenant CustomerId sequence — shared with the sales import so
    // both can run concurrently for the same channel without handing out duplicate ids.
    private readonly ImportIdAllocator _idAllocator;

    public CustomerImportRepository(
        ILogger<CustomerImportRepository> logger,
        ApplicationDbContext dbContext,
        ICustomerRepository customerRepository,
        ICountryRepository countryRepository,
        ImportIdAllocator idAllocator)
    {
        _logger = logger;
        _dbContext = dbContext;
        _customerRepository = customerRepository;
        _countryRepository = countryRepository;
        _idAllocator = idAllocator;
    }

    public async Task ImportOrUpdateFromSalesChannel(SalesChannel salesChannel, SalesChannelImportCustomer importCustomer)
    {
        // Every repository in this run shares one scoped DbContext. If a customer fails mid-save its
        // half-applied Added/Modified entries stay tracked and poison the next SaveChanges, turning one bad
        // customer into a run-wide cascade. Each customer is self-contained and prior ones are already
        // persisted, so on failure we revert just this customer's pending changes and rethrow so the
        // connector logs and counts the single failure.
        try
        {
            await ImportOrUpdateCoreAsync(salesChannel, importCustomer);

            // Everything this customer committed is now Unchanged ballast; drop it so DetectChanges stays
            // cheap for the thousands of customers that follow (run row + channel entity stay tracked).
            _dbContext.TrimCommittedEntries();
        }
        catch
        {
            _dbContext.DiscardPendingChanges();
            throw;
        }
    }

    private async Task ImportOrUpdateCoreAsync(SalesChannel salesChannel, SalesChannelImportCustomer importCustomer)
    {
        // Look the customer up by remote id first.
        var existingCustomer = await _customerRepository.GetCustomerByRemoteCustomerIdAsync(salesChannel.Id, importCustomer.RemoteCustomerId);

        // Not found by remote id — fall back to matching on email.
        if (existingCustomer == null && !string.IsNullOrEmpty(importCustomer.Email))
        {
            existingCustomer = await _customerRepository.GetCustomerByEmailAsync(importCustomer.Email);

            // Matched by email — link the existing customer to this sales channel.
            if (existingCustomer != null)
            {
                AddCustomerSalesChannelLink(existingCustomer.Id, salesChannel.Id, importCustomer.RemoteCustomerId);
                _logger.LogDebug("CustomerSalesChannel link added for customer {CustomerId}", existingCustomer.Id);
            }
        }

        // Create the customer when no existing match was found.
        var customerIsNew = existingCustomer == null;
        if (existingCustomer == null)
        {
            var newCustomer = new Customer
            {
                // Assign CustomerId from the shared allocator (seeded once per process) — no MAX scan per row.
                CustomerId = await _idAllocator.NextAsync(salesChannel.TenantId, ImportIdAllocator.CustomerKind,
                    async () => await _customerRepository.GetMaxCustomerIdAsync()),
                Email = importCustomer.Email ?? string.Empty,
                Firstname = importCustomer.Firstname ?? string.Empty,
                Lastname = importCustomer.Lastname ?? string.Empty,
                CompanyName = importCustomer.CompanyName ?? string.Empty,
                Phone = importCustomer.Phone ?? string.Empty,
                Website = importCustomer.Website ?? string.Empty,
                VatNumber = importCustomer.VatNumber ?? string.Empty,
                Note = importCustomer.Note ?? string.Empty,
                CustomerStatus = importCustomer.CustomerStatus != 0 ? importCustomer.CustomerStatus : CustomerStatus.Active,
                DateEnrollment = importCustomer.DateEnrollment != DateTime.MinValue ? importCustomer.DateEnrollment : DateTime.UtcNow
            };

            // Deferred: added to the context now, committed with the link + addresses in one SaveChanges below.
            _dbContext.Customer.Add(newCustomer);
            _logger.LogDebug("Customer {Email} created", importCustomer.Email);

            AddCustomerSalesChannelLink(newCustomer.Id, salesChannel.Id, importCustomer.RemoteCustomerId);
            _logger.LogDebug("CustomerSalesChannel link added for customer {CustomerId}", newCustomer.Id);

            existingCustomer = newCustomer;
        }
        else
        {
            // Update the existing customer.
            existingCustomer.Email = !string.IsNullOrEmpty(importCustomer.Email) ? importCustomer.Email : existingCustomer.Email;
            existingCustomer.Firstname = !string.IsNullOrEmpty(importCustomer.Firstname) ? importCustomer.Firstname : existingCustomer.Firstname;
            existingCustomer.Lastname = !string.IsNullOrEmpty(importCustomer.Lastname) ? importCustomer.Lastname : existingCustomer.Lastname;
            existingCustomer.CompanyName = !string.IsNullOrEmpty(importCustomer.CompanyName) ? importCustomer.CompanyName : existingCustomer.CompanyName;
            existingCustomer.Phone = !string.IsNullOrEmpty(importCustomer.Phone) ? importCustomer.Phone : existingCustomer.Phone;

            // The customer may have first been created from an order (or out of order) with a later date than
            // their real WooCommerce registration. Only ever move the enrollment date earlier so the customer
            // is never newer than their history; re-running the customer import then heals stale dates.
            if (importCustomer.DateEnrollment != DateTime.MinValue)
            {
                var registered = new DateTimeOffset(DateTime.SpecifyKind(importCustomer.DateEnrollment, DateTimeKind.Utc));
                if (registered < existingCustomer.DateEnrollment)
                {
                    existingCustomer.DateEnrollment = registered;
                }
            }

            // Mutation only — the tracked entity is persisted by the single SaveChanges at the end.
            _logger.LogDebug("Customer {CustomerId} updated", existingCustomer.Id);
        }

        // Process addresses (deferred adds).
        if (importCustomer.BillingAddress != null)
        {
            await ProcessAddress(existingCustomer, importCustomer.BillingAddress, customerIsNew);
        }

        if (importCustomer.ShippingAddress != null &&
            (importCustomer.BillingAddress == null ||
             !AreAddressesEqual(importCustomer.BillingAddress, importCustomer.ShippingAddress)))
        {
            await ProcessAddress(existingCustomer, importCustomer.ShippingAddress, customerIsNew);
        }

        // Single commit for the whole customer graph (customer + sales-channel link + addresses, new or
        // updated) — one round-trip per customer instead of the 2-4 the per-entity repository calls issued.
        await _dbContext.SaveChangesAsync();
    }

    private async Task ProcessAddress(Customer customer, SalesChannelImportCustomerAddress address, bool customerIsNew)
    {
        // An empty country is normal (e.g. a customer with no separate shipping address) — skip quietly
        // rather than logging a warning per row, which on a large import floods the log and sync buffer.
        if (string.IsNullOrWhiteSpace(address.Country))
        {
            return;
        }

        // Resolve the country from its ISO code.
        Country? country = await ResolveCountryAsync(address.Country);
        if (country == null)
        {
            _logger.LogWarning("Country with ISO code {IsoCode} not found", address.Country);
            return;
        }

        // A freshly created customer has no stored addresses yet (billing-vs-shipping duplication is
        // already guarded by AreAddressesEqual at the call site), so skip the existence query for them.
        if (!customerIsNew)
        {
            var existingAddresses = await _customerRepository.GetCustomerAddressByCustomerIdAsync(customer.Id);
            bool addressExists = existingAddresses.Any(a =>
                a.Street == address.Street &&
                a.City == address.City &&
                a.Zip == address.Zip &&
                a.CountryId == country.Id);

            if (addressExists)
            {
                return;
            }
        }

        var newAddress = new CustomerAddress
        {
            CustomerId = customer.Id,
            Firstname = address.Firstname,
            Lastname = address.Lastname,
            CompanyName = address.CompanyName,
            Street = address.Street,
            City = address.City,
            Zip = address.Zip,
            CountryId = country.Id
        };

        // Deferred: committed with the customer graph in the single SaveChanges of the caller.
        _dbContext.CustomerAddress.Add(newAddress);
        _logger.LogDebug("New address added for customer {CustomerId}", customer.Id);
    }

    /// <summary>Adds a customer↔sales-channel link to the context (deferred; committed with the customer).</summary>
    private void AddCustomerSalesChannelLink(Guid customerId, Guid salesChannelId, string remoteCustomerId)
    {
        _dbContext.CustomerSalesChannel.Add(new CustomerSalesChannel
        {
            CustomerId = customerId,
            SalesChannelId = salesChannelId,
            RemoteCustomerId = remoteCustomerId,
        });
    }

    /// <summary>Resolves a country by name or ISO code from an all-countries cache loaded once per run.</summary>
    private async Task<Country?> ResolveCountryAsync(string? country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            return null;
        }

        if (_countryCache == null)
        {
            _countryCache = new Dictionary<string, Country>(StringComparer.OrdinalIgnoreCase);
            foreach (var c in await _countryRepository.GetAllAsync())
            {
                if (!string.IsNullOrEmpty(c.Name))
                {
                    _countryCache[c.Name] = c;
                }
                if (!string.IsNullOrEmpty(c.CountryCode))
                {
                    _countryCache[c.CountryCode] = c;
                }
            }
        }

        return _countryCache.TryGetValue(country, out var found) ? found : null;
    }

    private bool AreAddressesEqual(SalesChannelImportCustomerAddress address1, SalesChannelImportCustomerAddress address2)
    {
        return address1.Street == address2.Street &&
               address1.City == address2.City &&
               address1.Zip == address2.Zip &&
               address1.Country == address2.Country;
    }
}
