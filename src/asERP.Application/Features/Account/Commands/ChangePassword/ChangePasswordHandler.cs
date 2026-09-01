using asERP.Application.Contracts.Logging;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace asERP.Application.Features.Account.Commands.ChangePassword;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, Result<string>>
{
    private readonly IAppLogger<ChangePasswordHandler> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public ChangePasswordHandler(
        IAppLogger<ChangePasswordHandler> logger,
        IHttpContextAccessor httpContextAccessor,
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<Result<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<string>();

        var userId = _httpContextAccessor.HttpContext.GetUserId();
        if (string.IsNullOrWhiteSpace(userId))
        {
            result.Fail(ErrorType.Unauthorized, ErrorCodes.Account.Unauthorized, "Authenticated user context is required.");
            return result;
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Account.NotFound, "Current user not found.");
            return result;
        }

        var changeResult = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!changeResult.Succeeded)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Account.Invalid);
            result.Messages.AddRange(changeResult.Errors.Select(e => e.Description));
            _logger.LogWarning("Password change failed for user {UserId}: {Errors}", userId,
                string.Join(", ", result.Messages));
            return result;
        }

        user.DateModified = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        result.Succeeded = true;
        result.Status = ResultStatus.NoContent;
        result.Data = user.Id;

        _logger.LogInformation("User {UserId} changed own password", user.Id);

        return result;
    }
}
