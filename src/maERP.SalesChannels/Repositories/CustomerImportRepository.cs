using maERP.Application.Contracts.Persistence;
using maERP.Domain.Entities;
using maERP.Domain.Enums;
using maERP.Persistence.DatabaseContext;
using maERP.SalesChannels.Contracts;
using maERP.SalesChannels.Models;
using Microsoft.Extensions.Logging;

namespace maERP.SalesChannels.Repositories;

public class CustomerImportRepository : ICustomerImportRepository
{
    private readonly ILogger<CustomerImportRepository> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICountryRepository _countryRepository;

    // Per-run caches. The repository is scoped, so one instance serves a whole import run and these reset
    // on the next run. They turn per-customer DB round-trips into one-off lookups:
    //  - _countryCache:   all countries loaded once instead of a SELECT per address.
    //  - _nextCustomerId: the per-tenant CustomerId max read once, then incremented in memory, instead of
    //                     a MAX scan over the growing customer table for every inserted row.
    private Dictionary<string, Country>? _countryCache;
    private int? _nextCustomerId;

    public CustomerImportRepository(
        ILogger<CustomerImportRepository> logger,
        ApplicationDbContext dbContext,
        ICustomerRepository customerRepository,
        ICountryRepository countryRepository)
    {
        _logger = logger;
        _dbContext = dbContext;
        _customerRepository = customerRepository;
        _countryRepository = countryRepository;
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
        }
        catch
        {
            _dbContext.DiscardPendingChanges();
            throw;
        }
    }

    private async Task ImportOrUpdateCoreAsync(SalesChannel salesChannel, SalesChannelImportCustomer importCustomer)
    {
        // Überprüfen, ob Kunde bereits existiert (nach Remote-ID suchen)
        var existingCustomer = await _customerRepository.GetCustomerByRemoteCustomerIdAsync(salesChannel.Id, importCustomer.RemoteCustomerId);

        // Wenn nicht nach Remote-ID gefunden, nach E-Mail suchen
        if (existingCustomer == null && !string.IsNullOrEmpty(importCustomer.Email))
        {
            existingCustomer = await _customerRepository.GetCustomerByEmailAsync(importCustomer.Email);

            // Wenn nach E-Mail gefunden, Verknüpfung mit SalesChannel herstellen
            if (existingCustomer != null)
            {
                await _customerRepository.AddCustomerToSalesChannelAsync(existingCustomer.Id, salesChannel.Id, importCustomer.RemoteCustomerId);
                _logger.LogInformation($"CustomerSalesChannel hinzugefügt für Kunden {existingCustomer.Id}");
            }
        }

        // Wenn Kunde nicht existiert, neu anlegen
        var customerIsNew = existingCustomer == null;
        if (existingCustomer == null)
        {
            var newCustomer = new Customer
            {
                // Assign CustomerId from the per-run counter (seeded once) so CreateAsync skips its MAX scan.
                CustomerId = await NextCustomerIdAsync(),
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

            await _customerRepository.CreateAsync(newCustomer);
            _logger.LogInformation($"Kunde {importCustomer.Email} erstellt");

            // Verknüpfung mit SalesChannel herstellen
            await _customerRepository.AddCustomerToSalesChannelAsync(newCustomer.Id, salesChannel.Id, importCustomer.RemoteCustomerId);
            _logger.LogInformation($"CustomerSalesChannel hinzugefügt für Kunden {newCustomer.Id}");

            existingCustomer = newCustomer;
        }
        else
        {
            // Bestehenden Kunden aktualisieren
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

            await _customerRepository.UpdateAsync(existingCustomer);
            _logger.LogInformation($"Kunde {existingCustomer.Id} aktualisiert");
        }

        // Adressen verarbeiten
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
    }

    private async Task ProcessAddress(Customer customer, SalesChannelImportCustomerAddress address, bool customerIsNew)
    {
        // An empty country is normal (e.g. a customer with no separate shipping address) — skip quietly
        // rather than logging a warning per row, which on a large import floods the log and sync buffer.
        if (string.IsNullOrWhiteSpace(address.Country))
        {
            return;
        }

        // Land aus ISO-Code ermitteln
        Country? country = await ResolveCountryAsync(address.Country);
        if (country == null)
        {
            _logger.LogWarning($"Land mit ISO-Code {address.Country} nicht gefunden");
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

        await _customerRepository.AddCustomerAddressAsync(newAddress);
        _logger.LogInformation($"Neue Adresse für Kunden {customer.Id} hinzugefügt");
    }

    /// <summary>Next per-tenant CustomerId, seeding the counter from the DB max on first use.</summary>
    private async Task<int> NextCustomerIdAsync()
    {
        _nextCustomerId ??= await _customerRepository.GetMaxCustomerIdAsync() + 1;
        return _nextCustomerId++.Value;
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