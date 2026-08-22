using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.SalesChannel;

/// <summary>
/// Ad-hoc connection test input for a sales channel that has not been persisted yet
/// (create wizard: the credentials are validated before the channel is saved).
/// </summary>
public class SalesChannelConnectionTestInputDto
{
    public SalesChannelType SalesChannelType { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Free-form connector configuration (schema owned by the connector — e.g. MySQL host/database/
    /// table prefix for WooCommerceDatabase). Must not contain secrets; those belong in Password.
    /// </summary>
    public string? AdditionalConfigJson { get; set; }
}
