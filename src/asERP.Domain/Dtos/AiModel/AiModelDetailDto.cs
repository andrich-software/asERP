using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.AiModel;

public class AiModelDetailDto
{
    public Guid Id { get; set; }
    public AiModelType AiModelType { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ApiUsername { get; set; } = string.Empty;

    /// <summary>Never exposes the stored secret — always empty. Use <see cref="HasApiPassword"/> to check whether one is set.</summary>
    public string ApiPassword { get; set; } = string.Empty;

    /// <summary>Never exposes the stored secret — always empty. Use <see cref="HasApiKey"/> to check whether one is set.</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>True when an API password is stored (the secret itself is never exposed).</summary>
    public bool HasApiPassword { get; set; }

    /// <summary>True when an API key is stored (the secret itself is never exposed).</summary>
    public bool HasApiKey { get; set; }

    public uint NCtx { get; set; }
}
