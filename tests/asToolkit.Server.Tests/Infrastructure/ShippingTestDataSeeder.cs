using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Persistence.DatabaseContext;

namespace asToolkit.Server.Tests.Infrastructure;

/// <summary>
/// Direct-DbContext arrangement helpers for the shipping feature tests. All methods only add
/// entities to the context — callers must SaveChangesAsync afterwards.
/// </summary>
public static class ShippingTestDataSeeder
{
    // Deterministic seed ids from CountryConfiguration.HasData.
    public static readonly Guid GermanyCountryId = Guid.Parse("00000000-0000-0000-0000-000000000001");
    public static readonly Guid AustriaCountryId = Guid.Parse("00000000-0000-0000-0000-000000000002");
    public static readonly Guid SwitzerlandCountryId = Guid.Parse("00000000-0000-0000-0000-000000000003");

    /// <summary>
    /// The CountryConfiguration.HasData seed is not materialized in the InMemory test database,
    /// so the countries the shipping tests rely on are inserted explicitly (idempotent).
    /// </summary>
    public static void EnsureCountries(ApplicationDbContext context)
    {
        EnsureCountry(context, GermanyCountryId, "DE", "Germany");
        EnsureCountry(context, AustriaCountryId, "AT", "Austria");
        EnsureCountry(context, SwitzerlandCountryId, "CH", "Switzerland");
    }

    private static void EnsureCountry(ApplicationDbContext context, Guid id, string code, string name)
    {
        if (context.Country.Find(id) != null)
        {
            return;
        }

        context.Country.Add(new Country
        {
            Id = id,
            CountryCode = code,
            Name = name,
            TenantId = null
        });
    }

    public static ShippingProvider AddProvider(
        ApplicationDbContext context,
        Guid tenantId,
        string name = "DHL Provider",
        ShippingProviderType type = ShippingProviderType.Dhl,
        bool isEnabled = true,
        string password = "secret-password",
        string? apiKey = null,
        string? apiSecret = null)
    {
        var provider = new ShippingProvider
        {
            Id = Guid.NewGuid(),
            Name = name,
            Type = type,
            IsEnabled = isEnabled,
            UseSandbox = true,
            Username = "test-user",
            Password = password,
            ApiKey = apiKey,
            ApiSecret = apiSecret,
            TrackingPollIntervalSeconds = 3600,
            TenantId = tenantId
        };

        context.ShippingProvider.Add(provider);
        return provider;
    }

    public static ShippingProviderRate AddRate(
        ApplicationDbContext context,
        ShippingProvider provider,
        string name = "Standard Parcel",
        decimal maxLength = 120m,
        decimal maxWidth = 60m,
        decimal maxHeight = 60m,
        decimal maxWeight = 31.5m,
        decimal price = 5.99m,
        params Guid[] allowedCountryIds)
    {
        EnsureCountries(context);

        var rate = new ShippingProviderRate
        {
            Id = Guid.NewGuid(),
            ShippingProviderId = provider.Id,
            Name = name,
            MaxLength = maxLength,
            MaxWidth = maxWidth,
            MaxHeight = maxHeight,
            MaxWeight = maxWeight,
            Price = price,
            TenantId = provider.TenantId
        };

        context.ShippingProviderRate.Add(rate);

        var countryIds = allowedCountryIds.Length == 0 ? new[] { GermanyCountryId } : allowedCountryIds;
        foreach (var countryId in countryIds)
        {
            context.ShippingProviderRateCountry.Add(new ShippingProviderRateCountry
            {
                Id = Guid.NewGuid(),
                ShippingProviderRateId = rate.Id,
                CountryId = countryId,
                TenantId = provider.TenantId
            });
        }

        return rate;
    }

    /// <summary>
    /// Adds a customer plus a sales order with a complete delivery address.
    /// <paramref name="customerNumber"/> must be unique per test class — Customer.CustomerId
    /// is a principal key.
    /// </summary>
    public static Sales AddSales(
        ApplicationDbContext context,
        Guid tenantId,
        int customerNumber,
        string deliveryCountry = "Germany",
        int itemCount = 2)
    {
        EnsureCountries(context);

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            CustomerId = customerNumber,
            Firstname = "Ship",
            Lastname = $"Tester{customerNumber}",
            Email = $"ship.tester{customerNumber}@test.com",
            TenantId = tenantId
        };

        context.Customer.Add(customer);

        var sales = new Sales
        {
            Id = Guid.NewGuid(),
            SalesId = 30000 + customerNumber,
            CustomerId = customerNumber,
            SalesChannelId = Guid.NewGuid(),
            Status = SalesStatus.Processing,
            DeliveryAddressFirstName = "Ship",
            DeliveryAddressLastName = $"Tester{customerNumber}",
            DeliveryAddressStreet = "Teststrasse 1",
            DeliveryAddressCity = "Dresden",
            DeliveryAddressZip = "01067",
            DeliveryAddressCountry = deliveryCountry,
            DateSalesed = DateTime.UtcNow,
            TenantId = tenantId
        };

        for (var i = 0; i < itemCount; i++)
        {
            sales.SalesItems.Add(new SalesItem
            {
                Id = Guid.NewGuid(),
                SalesId = sales.Id,
                ProductId = Guid.NewGuid(),
                Name = $"Item {i + 1}",
                Quantity = 1,
                Price = 10m,
                TenantId = tenantId
            });
        }

        context.Sales.Add(sales);
        return sales;
    }

    public static Domain.Entities.Shipping AddShipping(
        ApplicationDbContext context,
        Sales sales,
        ShippingProvider provider,
        ShippingProviderRate? rate = null,
        ShippingStatus status = ShippingStatus.Open,
        string trackingNumber = "",
        byte[]? labelData = null,
        string? labelFormat = null)
    {
        var shipping = new Domain.Entities.Shipping
        {
            Id = Guid.NewGuid(),
            SalesId = sales.Id,
            ShippingProviderId = provider.Id,
            ShippingProviderRateId = rate?.Id,
            Status = status,
            TrackingNumber = trackingNumber,
            ShippingCost = rate?.Price ?? 4.99m,
            LabelData = labelData,
            LabelFormat = labelFormat,
            TenantId = sales.TenantId
        };

        context.Shipping.Add(shipping);
        return shipping;
    }
}
