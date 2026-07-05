using asERP.Application.Contracts.Logging;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace asERP.Application.Features.Account.Commands.UpdateCurrentUser;

public class UpdateCurrentUserHandler : IRequestHandler<UpdateCurrentUserCommand, Result<string>>
{
    private readonly IAppLogger<UpdateCurrentUserHandler> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public UpdateCurrentUserHandler(
        IAppLogger<UpdateCurrentUserHandler> logger,
        IHttpContextAccessor httpContextAccessor,
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<Result<string>> Handle(UpdateCurrentUserCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<string>();

        var validator = new UpdateCurrentUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
            return result;
        }

        var userId = _httpContextAccessor.HttpContext.GetUserId();
        if (string.IsNullOrWhiteSpace(userId))
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.Unauthorized;
            result.Messages.Add("Authenticated user context is required.");
            return result;
        }

        try
        {
            var existingUser = await _userManager.FindByIdAsync(userId);
            if (existingUser == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add("Current user not found.");
                return result;
            }

            var normalizedEmail = _userManager.NormalizeEmail(request.Email);
            var normalizedUserName = _userManager.NormalizeName(request.Email);

            if (!string.Equals(existingUser.NormalizedEmail, normalizedEmail, StringComparison.OrdinalIgnoreCase))
            {
                var userWithEmail = await _userManager.FindByEmailAsync(request.Email);
                var emailInUse = userWithEmail != null &&
                    !string.Equals(userWithEmail.Id, existingUser.Id, StringComparison.OrdinalIgnoreCase);

                if (emailInUse)
                {
                    result.Succeeded = false;
                    result.StatusCode = ResultStatusCode.BadRequest;
                    result.Messages.Add("Email address is already in use.");
                    return result;
                }
            }

            existingUser.Email = request.Email;
            existingUser.NormalizedEmail = normalizedEmail;
            existingUser.UserName = request.Email;
            existingUser.NormalizedUserName = normalizedUserName;
            existingUser.Firstname = request.Firstname;
            existingUser.Lastname = request.Lastname;
            existingUser.PhoneNumber = string.IsNullOrWhiteSpace(request.PhoneNumber) ? null : request.PhoneNumber;
            existingUser.DateModified = DateTime.UtcNow;

            var updateResult = await _userManager.UpdateAsync(existingUser);
            if (!updateResult.Succeeded)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.AddRange(updateResult.Errors.Select(e => e.Description));
                return result;
            }

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.NoContent;
            result.Data = existingUser.Id;

            _logger.LogInformation("Current user {UserId} updated own profile", existingUser.Id);
        }
        catch (Exception ex)
        {
            // Never leak the raw exception text.
            result.FromException(_logger, ex,
                "An error occurred while updating the current user.",
                "Error updating current user.");
        }

        return result;
    }
}
