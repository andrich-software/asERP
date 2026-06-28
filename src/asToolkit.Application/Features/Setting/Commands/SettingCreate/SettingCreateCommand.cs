using asToolkit.Domain.Dtos.Setting;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Setting.Commands.SettingCreate;

/// <summary>
/// Command for creating a new setting in the system.
/// Inherits from SettingInputDto to get all setting properties and implements IRequest
/// to work with MediatR, returning the ID of the newly created setting wrapped in a Result.
/// </summary>
public class SettingCreateCommand : SettingInputDto, IRequest<Result<Guid>>
{
}