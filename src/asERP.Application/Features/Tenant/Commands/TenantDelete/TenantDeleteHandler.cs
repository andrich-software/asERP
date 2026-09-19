using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Tenant.Commands.TenantDelete;

public class TenantDeleteHandler : IRequestHandler<TenantDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<TenantDeleteHandler> _logger;
    private readonly ITenantRepository _tenantRepository;
    private readonly ITenantPermissionService _tenantPermissionService;

    public TenantDeleteHandler(
        IAppLogger<TenantDeleteHandler> logger,
        ITenantRepository tenantRepository,
        ITenantPermissionService tenantPermissionService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _tenantRepository = tenantRepository ?? throw new ArgumentNullException(nameof(tenantRepository));
        _tenantPermissionService = tenantPermissionService ?? throw new ArgumentNullException(nameof(tenantPermissionService));
    }

    public async Task<Result<Guid>> Handle(TenantDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("User {UserId} is deleting tenant {TenantId}",
            request.UserId, request.TenantId);

        try
        {
            await _tenantRepository.DeleteTenantWithCascadeAsync(request.TenantId, cancellationToken);

            _logger.LogInformation("Successfully deleted tenant with ID: {TenantId}", request.TenantId);
            return Result<Guid>.NoContent(request.TenantId);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogWarning("Tenant with ID: {TenantId} was deleted by another request: {Message}",
                request.TenantId, ex.Message);
            return Result<Guid>.NotFound(ErrorCodes.Tenant.NotFound, "Tenant was already deleted by another request");
        }

    }
}
