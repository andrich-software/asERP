using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Setting.Commands.SettingDelete;

public class SettingDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}