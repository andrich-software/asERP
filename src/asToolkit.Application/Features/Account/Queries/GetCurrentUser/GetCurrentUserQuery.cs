using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Account;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Account.Queries.GetCurrentUser;

public class GetCurrentUserQuery : IRequest<Result<CurrentUserProfileDto>>
{
}
