using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Account.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<Result<string>>
{
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    public string NewPasswordConfirm { get; set; } = string.Empty;
}
