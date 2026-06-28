using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Customer;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Customer.Commands.CustomerDedupe;

public class CustomerDedupeHandler : IRequestHandler<CustomerDedupeCommand, Result<CustomerDedupeResultDto>>
{
    private readonly IAppLogger<CustomerDedupeHandler> _logger;
    private readonly ICustomerDedupeService _dedupeService;

    public CustomerDedupeHandler(
        IAppLogger<CustomerDedupeHandler> logger,
        ICustomerDedupeService dedupeService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dedupeService = dedupeService ?? throw new ArgumentNullException(nameof(dedupeService));
    }

    public async Task<Result<CustomerDedupeResultDto>> Handle(CustomerDedupeCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Customer dedupe started (dryRun={DryRun})", request.DryRun);

        try
        {
            var dto = await _dedupeService.RunAsync(request.DryRun, cancellationToken);

            _logger.LogInformation(
                "Customer dedupe finished (dryRun={DryRun}, tenants={Tenants}, groups={Groups}, customersToMerge={CustomersToMerge})",
                request.DryRun, dto.TenantsAffected, dto.GroupsFound, dto.CustomersToMerge);

            return Result<CustomerDedupeResultDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Customer dedupe failed: {Message}", ex.Message);
            return Result<CustomerDedupeResultDto>.Fail(ResultStatusCode.InternalServerError,
                $"Customer dedupe failed: {ex.Message}");
        }
    }
}
