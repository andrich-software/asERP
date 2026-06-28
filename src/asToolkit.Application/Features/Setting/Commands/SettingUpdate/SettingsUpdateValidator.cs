using FluentValidation;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Validators;

namespace asToolkit.Application.Features.Setting.Commands.SettingUpdate;

public class SettingUpdateValidator : SettingBaseValidator<SettingUpdateCommand>
{
    private readonly ISettingRepository _settingRepository;

    public SettingUpdateValidator(ISettingRepository settingRepository)
    {
        _settingRepository = settingRepository;

        RuleFor(p => p.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");

        RuleFor(s => s)
            .MustAsync(IsUnique).WithMessage("Setting is not unique.");
    }

    private async Task<bool> IsUnique(SettingUpdateCommand command, CancellationToken cancellationToken)
    {
        var setting = new Domain.Entities.Setting()
        {
            Key = command.Key
        };

        var test = await _settingRepository.IsUniqueAsync(setting, command.Id);

        return test;
    }
}