using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Account.Commands.UpdateCurrentUser;

public class UpdateCurrentUserCommand : IRequest<Result<string>>
{
    public string Email { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
