namespace asToolkit.Domain.Enums;

/// <summary>
/// Supported shipping carriers. Selects the connector used for label creation and tracking.
/// </summary>
public enum ShippingProviderType
{
    Dhl = 1,
    Dpd = 2,
    Gls = 3,
    Ups = 4
}
