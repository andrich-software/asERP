using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Setting.Commands.SettingDelete;

public class SettingDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}