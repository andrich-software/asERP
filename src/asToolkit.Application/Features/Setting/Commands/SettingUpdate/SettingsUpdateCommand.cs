using asToolkit.Domain.Dtos.Setting;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Setting.Commands.SettingUpdate;

public class SettingUpdateCommand : SettingInputDto, IRequest<Result<Guid>>
{
}