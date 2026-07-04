using System.Text.Json.Serialization;

namespace asERP.Domain.Dtos.Tenant;

public class TenantDetailDto : TenantDtoBase
{
    [JsonPropertyName("userCount")]
    public int UserCount { get; set; }

    [JsonPropertyName("canManageTenant")]
    public bool CanManageTenant { get; set; }

    [JsonPropertyName("packingSlipShowPrices")]
    public bool PackingSlipShowPrices { get; set; }

    [JsonPropertyName("packingSlipPrintByDefault")]
    public bool PackingSlipPrintByDefault { get; set; }
}
