using asERP.Application.Mediator;
using asERP.Domain.Dtos.Account;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Account.Queries.GetCurrentUser;

public class GetCurrentUserQuery : IRequest<Result<CurrentUserProfileDto>>
{
}
