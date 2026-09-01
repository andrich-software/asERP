using asERP.Application.Mediator;
using asERP.Domain.Dtos.User;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Superadmin.Users.Queries.UserDetail;

/// <summary>
/// Query for retrieving detailed information about a specific user.
/// Implements IRequest to work with the custom mediator, returning user details wrapped in a Result.
/// </summary>
public class UserDetailQuery : IRequest<Result<UserDetailDto>>
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public string Id { get; set; } = string.Empty;
}
