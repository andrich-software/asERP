using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Services;

/// <summary>
/// Resolves an order's free-text delivery country against the seeded country list.
/// Shared between shipment creation and the shipping-options query so both produce
/// identical error texts.
/// </summary>
public interface IShippingDestinationResolver
{
    Task<ShippingDestinationResult> ResolveAsync(Sales sales);
}

/// <summary>Outcome of a destination resolution: either a country or an error text, never both.</summary>
public class ShippingDestinationResult
{
    public Country? Country { get; init; }
    public string? Error { get; init; }
}
