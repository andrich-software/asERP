using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Commands.SettingDelete;

public class SettingDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
