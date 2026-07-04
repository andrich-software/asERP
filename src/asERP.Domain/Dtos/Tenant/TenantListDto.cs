using System.Text.Json.Serialization;

namespace asERP.Domain.Dtos.Tenant;

public class TenantListDto : TenantDtoBase
{
    [JsonPropertyName("canManageTenant")]
    public bool CanManageTenant { get; set; }
}
