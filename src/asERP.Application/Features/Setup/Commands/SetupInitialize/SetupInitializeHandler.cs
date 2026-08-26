using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Application.Features.Tenant.Commands.TenantCreate;
using asERP.Application.Mediator;
using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setup.Commands.SetupInitialize;

/// <summary>
/// Runs the initial server setup: creates the first Superadmin account, creates the first
/// tenant via the regular <see cref="TenantCreateCommand"/> (default warehouse, tax classes
/// and POS channel included) and persists the System.SetupCompleted flag. The endpoint is
/// anonymous, so the handler refuses as soon as any user exists or the flag is already set.
/// </summary>
public class SetupInitializeHandler : IRequestHandler<SetupInitializeCommand, Result<Guid>>
{
    /// <summary>
    /// Serializes concurrent setup attempts — two racing anonymous requests must not both
    /// pass the "setup still pending" guard and each create a Superadmin.
    /// </summary>
    private static readonly SemaphoreSlim SetupLock = new(1, 1);

    private readonly IAppLogger<SetupInitializeHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ISettingsService _settingsService;
    private readonly ISetupStatusService _setupStatusService;
    private readonly IMediator _mediator;

    public SetupInitializeHandler(
        IAppLogger<SetupInitializeHandler> logger,
        IUserRepository userRepository,
        ISettingsService settingsService,
        ISetupStatusService setupStatusService,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));
        _setupStatusService = setupStatusService ?? throw new ArgumentNullException(nameof(setupStatusService));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(SetupInitializeCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Initial server setup requested for {Email}", request.Email);

        var result = new Result<Guid>();

        await SetupLock.WaitAsync(cancellationToken);
        try
        {
            // Guard before validation: once the window is closed, the anonymous endpoint must
            // answer identically for every payload — the email-uniqueness rule would otherwise
            // let anyone probe which accounts exist.
            if (!await _setupStatusService.IsSetupRequiredAsync())
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.Forbidden;
                result.Messages.Add("Die Ersteinrichtung wurde bereits abgeschlossen.");
                return result;
            }

            var validator = new SetupInitializeValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

                _logger.LogWarning("Validation errors in create request for {0}: {1}",
                    nameof(SetupInitializeCommand),
                    string.Join(", ", result.Messages));

                return result;
            }

            var superadmin = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            var createErrors = (await _userRepository.CreateSuperadminAsync(superadmin, request.Password)).ToList();
            if (createErrors.Count > 0)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.AddRange(createErrors.Select(e => e.Description));
                return result;
            }

            var tenantResult = await _mediator.Send(new TenantCreateCommand
            {
                Name = request.TenantName,
                Description = request.TenantDescription,
                UserId = superadmin.Id
            }, cancellationToken);

            if (!tenantResult.Succeeded)
            {
                await DeleteSuperadminBestEffortAsync(superadmin);

                result.Succeeded = false;
                result.StatusCode = tenantResult.StatusCode;
                result.Messages.AddRange(tenantResult.Messages);
                return result;
            }

            await _settingsService.SetSettingValueAsync(SettingKeys.SetupCompleted, "True");

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = tenantResult.Data;

            _logger.LogInformation(
                "Initial server setup completed: Superadmin {UserId} and tenant {TenantId} created",
                superadmin.Id, tenantResult.Data);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred during the initial server setup.",
                "Error running initial server setup for {Email}.", request.Email);
        }
        finally
        {
            SetupLock.Release();
        }

        return result;
    }

    /// <summary>
    /// Mirrors the CLI's cleanup: when tenant creation fails, the half-configured
    /// Superadmin is removed again so a retry starts from a clean state.
    /// </summary>
    private async Task DeleteSuperadminBestEffortAsync(ApplicationUser superadmin)
    {
        try
        {
            await _userRepository.DeleteAsync(superadmin);
        }
        catch (Exception ex)
        {
            _logger.LogWarning("Could not clean up Superadmin {UserId} after failed setup: {Message}",
                superadmin.Id, ex.Message);
        }
    }
}
