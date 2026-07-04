using asERP.Domain.Dtos.Setting;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Setting.Commands.SettingUpdate;

public class SettingUpdateCommand : SettingInputDto, IRequest<Result<Guid>>
{
}