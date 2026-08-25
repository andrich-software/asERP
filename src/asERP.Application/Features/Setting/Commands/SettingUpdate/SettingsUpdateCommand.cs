using asERP.Application.Mediator;
using asERP.Domain.Dtos.Setting;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Commands.SettingUpdate;

public class SettingUpdateCommand : SettingInputDto, IRequest<Result<Guid>>
{
}
