using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

public class AiModel : BaseEntity, IBaseEntity
{
    public AiModelType AiModelType { get; set; } = AiModelType.None;
    public string Name { get; set; } = string.Empty;
    public string ApiUrl { get; set; } = string.Empty;
    public string ApiUsername { get; set; } = string.Empty;
    public string ApiPassword { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public uint NCtx { get; set; } = 0;
    public List<AiPrompt> AiPrompts { get; set; } = new();
}