using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

public class AiPrompt : BaseEntity, IBaseEntity
{
    public Guid AiModelId { get; set; }
    public string Identifier { get; set; } = string.Empty;
    public string PromptText { get; set; } = string.Empty;
}