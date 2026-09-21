using asERP.Application.Services;

namespace asERP.Application.Features.ShippingProvider;

/// <summary>
/// Secret rules for <c>ShippingProvider.AdditionalConfigJson</c>, kept in one place so the detail
/// query and the create/update commands can never disagree about which keys of the blob are
/// credentials.
/// </summary>
public static class ShippingProviderConfigSecrets
{
    /// <summary>
    /// The only credential in the carrier configs today: <c>DhlCarrierConfig.TrackingApiKey</c>,
    /// sent as the <c>DHL-API-Key</c> header by the DHL tracking client.
    /// </summary>
    private static readonly string[] SecretKeys = ["TrackingApiKey"];

    /// <summary>
    /// Every remaining key of the carrier configs (<c>asERP.Shipping/Models/</c>:
    /// Dhl/Dpd/Gls/UpsCarrierConfig and the shared CarrierSenderAddress). Listing them keeps the
    /// redactor's name-based catch-all from masking a setting the connectors need.
    /// </summary>
    private static readonly string[] PlainKeys =
    [
        "Procedure", "Participation", "Product", "ReturnReceiverId", "ReturnProcedure",
        "LabelSize", "ReturnProduct", "ContactId", "ServiceCode",
        "Sender", "Name", "Street", "Zip", "City", "CountryCode", "Email", "Phone"
    ];

    public static ConfigJsonSecretRedactor Redactor { get; } = new(SecretKeys, PlainKeys);
}
