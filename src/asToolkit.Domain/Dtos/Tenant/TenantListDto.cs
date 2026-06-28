using System.Text.Json.Serialization;

namespace asToolkit.Domain.Dtos.Tenant;

public class TenantListDto : TenantDtoBase
{
    [JsonPropertyName("canManageTenant")]
    public bool CanManageTenant { get; set; }
}
