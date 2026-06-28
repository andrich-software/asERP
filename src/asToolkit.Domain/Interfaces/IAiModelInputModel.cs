using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Interfaces;

public interface IAiModelInputModel
{
    string Name { get; }
    AiModelType AiModelType { get; }
    string ApiUrl { get; }
    string ApiUsername { get; }
    string ApiPassword { get; }
    string ApiKey { get; }
    uint NCtx { get; }
}