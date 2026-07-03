namespace asToolkit.Shipping.Models.Common;

/// <summary>
/// Sender address block shared by all carrier configs — part of the provider's
/// AdditionalConfigJson.
/// </summary>
public sealed class CarrierSenderAddress
{
    public string Name { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    /// <summary>ISO 3166-1 alpha-2, e.g. "DE".</summary>
    public string CountryCode { get; set; } = "DE";

    public string? Email { get; set; }
    public string? Phone { get; set; }

    public void EnsureComplete(string providerName)
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Street)
            || string.IsNullOrWhiteSpace(Zip) || string.IsNullOrWhiteSpace(City))
        {
            throw new InvalidOperationException(
                $"Shipping provider '{providerName}' has no complete sender address in AdditionalConfigJson " +
                "(required: Sender.Name, Sender.Street, Sender.Zip, Sender.City).");
        }
    }
}
