using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantEmailSettings.Commands.TenantEmailSettingsDelete;

public class TenantEmailSettingsDeleteHandler : IRequestHandler<TenantEmailSettingsDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<TenantEmailSettingsDeleteHandler> _logger;
    private readonly ITenantEmailSettingsRepository _repository;
    private readonly ITenantContext _tenantContext;

    public TenantEmailSettingsDeleteHandler(
        IAppLogger<TenantEmailSettingsDeleteHandler> logger,
        ITenantEmailSettingsRepository repository,
        ITenantContext tenantContext)
    {
        _logger = logger;
        _repository = repository;
        _tenantContext = tenantContext;
    }

    public async Task<Result<Guid>> Handle(TenantEmailSettingsDeleteCommand request, CancellationToken cancellationToken)
    {
        var tenantId = _tenantContext.GetCurrentTenantId();
        if (!tenantId.HasValue)
        {
            return Result<Guid>.Invalid(ErrorCodes.TenantEmailSettings.Invalid, "No active tenant in context.");
        }

        var existing = await _repository.GetByTenantIdAsync(tenantId.Value);
        if (existing == null)
        {
            return Result<Guid>.NotFound(ErrorCodes.TenantEmailSettings.NotFound, "No tenant-level email configuration to delete.");
        }

        await _repository.DeleteAsync(existing);

        _logger.LogInformation("Deleted tenant email settings for tenant {TenantId}", tenantId.Value);
        return Result<Guid>.NoContent(existing.Id);
    }
}
