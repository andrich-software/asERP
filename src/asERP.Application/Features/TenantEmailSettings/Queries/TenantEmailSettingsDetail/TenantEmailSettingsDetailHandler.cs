using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.TenantEmailSettings;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantEmailSettings.Queries.TenantEmailSettingsDetail;

public class TenantEmailSettingsDetailHandler : IRequestHandler<TenantEmailSettingsDetailQuery, Result<TenantEmailSettingsDetailDto>>
{
    private readonly IAppLogger<TenantEmailSettingsDetailHandler> _logger;
    private readonly ITenantEmailSettingsRepository _repository;
    private readonly ITenantContext _tenantContext;

    public TenantEmailSettingsDetailHandler(
        IAppLogger<TenantEmailSettingsDetailHandler> logger,
        ITenantEmailSettingsRepository repository,
        ITenantContext tenantContext)
    {
        _logger = logger;
        _repository = repository;
        _tenantContext = tenantContext;
    }

    public async Task<Result<TenantEmailSettingsDetailDto>> Handle(TenantEmailSettingsDetailQuery request, CancellationToken cancellationToken)
    {
        var result = new Result<TenantEmailSettingsDetailDto>();

        var tenantId = _tenantContext.GetCurrentTenantId();
        if (!tenantId.HasValue)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.TenantEmailSettings.Invalid, "No active tenant in context.");
            return result;
        }

        var entity = await _repository.GetByTenantIdAsync(tenantId.Value);
        if (entity == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.TenantEmailSettings.NotFound, "No tenant-level email configuration found. Server defaults apply.");
            return result;
        }

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = new TenantEmailSettingsDetailDto
        {
            Id = entity.Id,
            TenantId = entity.TenantId,
            ProviderType = entity.ProviderType,
            IsActive = entity.IsActive,
            SmtpHost = entity.SmtpHost,
            SmtpPort = entity.SmtpPort,
            SmtpUsername = entity.SmtpUsername,
            SmtpPasswordIsSet = !string.IsNullOrEmpty(entity.SmtpPassword),
            SmtpEnableSsl = entity.SmtpEnableSsl,
            M365TenantId = entity.M365TenantId,
            M365ClientId = entity.M365ClientId,
            M365ClientSecretIsSet = !string.IsNullOrEmpty(entity.M365ClientSecret),
            M365SenderAddress = entity.M365SenderAddress,
            FromAddress = entity.FromAddress,
            FromName = entity.FromName,
            ReplyToAddress = entity.ReplyToAddress,
            ReplyToName = entity.ReplyToName,
            DateCreated = entity.DateCreated,
            DateModified = entity.DateModified
        };

        _logger.LogInformation("Returning tenant email settings for tenant {TenantId}", tenantId.Value);
        return result;
    }
}
