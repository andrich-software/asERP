using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Validators;
using FluentValidation;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptCreate;

public class AiPromptCreateValidator : AiPromptBaseValidator<AiPromptCreateCommand>
{
    private readonly IAiPromptRepository _aIPromptRepository;
    private readonly IAiModelRepository _aiModelRepository;
    private readonly ITenantContext _tenantContext;

    public AiPromptCreateValidator(IAiPromptRepository aiPromptRepository, IAiModelRepository aiModelRepository, ITenantContext tenantContext)
    {
        _aIPromptRepository = aiPromptRepository;
        _aiModelRepository = aiModelRepository;
        _tenantContext = tenantContext;

        RuleFor(q => q)
            .MustAsync(IsUniqueAsync).WithMessage("AiPrompt with the same Identifier already exists.");

        RuleFor(p => p.AiModelId)
            .MustAsync(ValidateAiModelTenantAccessAsync).WithMessage("AI Model not found or does not belong to current tenant.");
    }

    private async Task<bool> IsUniqueAsync(AiPromptCreateCommand command, CancellationToken cancellationToken)
    {
        var aiPrompt = new Domain.Entities.AiPrompt
        {
            Identifier = command.Identifier
        };

        return await _aIPromptRepository.IsUniqueAsync(aiPrompt);
    }

    private async Task<bool> ValidateAiModelTenantAccessAsync(Guid aiModelId, CancellationToken cancellationToken)
    {
        // The repository read is subject to the global tenant query filter, so a cross-tenant
        // AiModel resolves to null. When no tenant context is set, defer to the handler.
        var currentTenantId = _tenantContext.GetCurrentTenantId();
        if (!currentTenantId.HasValue)
        {
            return true;
        }

        var aiModel = await _aiModelRepository.GetByIdAsync(aiModelId);
        return aiModel != null && aiModel.TenantId == currentTenantId.Value;
    }
}
