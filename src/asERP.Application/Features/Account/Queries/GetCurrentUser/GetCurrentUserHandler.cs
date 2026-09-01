using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Account;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;

namespace asERP.Application.Features.Account.Queries.GetCurrentUser;

public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, Result<CurrentUserProfileDto>>
{
    private readonly IAppLogger<GetCurrentUserHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetCurrentUserHandler(
        IAppLogger<GetCurrentUserHandler> logger,
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public async Task<Result<CurrentUserProfileDto>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var result = new Result<CurrentUserProfileDto>();

        var userId = _httpContextAccessor.HttpContext.GetUserId();
        if (string.IsNullOrWhiteSpace(userId))
        {
            result.Fail(ErrorType.Unauthorized, ErrorCodes.Account.Unauthorized, "Authenticated user context is required.");
            return result;
        }

        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Account.NotFound, "Current user not found.");
            _logger.LogWarning("Authenticated user {UserId} not found in database", userId);
            return result;
        }

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = new CurrentUserProfileDto
        {
            Id = user.Id,
            Email = user.Email ?? string.Empty,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            PhoneNumber = user.PhoneNumber ?? string.Empty
        };

        return result;
    }
}
