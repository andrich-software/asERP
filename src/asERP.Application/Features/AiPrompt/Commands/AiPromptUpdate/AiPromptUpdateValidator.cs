using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Validators;
using FluentValidation;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptUpdate;

public class AiPromptUpdateValidator : AiPromptBaseValidator<AiPromptUpdateCommand>
{
    private readonly IAiPromptRepository _aIPromptRepository;
    private readonly IAiModelRepository _aiModelRepository;
    private readonly ITenantContext _tenantContext;

    public AiPromptUpdateValidator(IAiPromptRepository aIPromptRepository, IAiModelRepository aiModelRepository, ITenantContext tenantContext)
    {
        _aIPromptRepository = aIPromptRepository;
        _aiModelRepository = aiModelRepository;
        _tenantContext = tenantContext;

        RuleFor(w => w)
            .MustAsync(IsUniqueAsync).WithMessage("AiPrompt with the same name already exists.");

        RuleFor(p => p.AiModelId)
            .MustAsync(ValidateAiModelTenantAccessAsync).WithMessage("AI Model not found or does not belong to current tenant.");
    }


    private async Task<bool> IsUniqueAsync(AiPromptUpdateCommand command, CancellationToken cancellationToken)
    {
        var aIPrompt = new Domain.Entities.AiPrompt
        {
            Id = command.Id,
            Identifier = command.Identifier,
        };
        return await _aIPromptRepository.IsUniqueAsync(aIPrompt, command.Id);
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
