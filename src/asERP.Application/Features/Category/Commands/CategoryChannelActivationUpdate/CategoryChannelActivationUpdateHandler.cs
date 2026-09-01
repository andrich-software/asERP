using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Services;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Category.Commands.CategoryChannelActivationUpdate;

public class CategoryChannelActivationUpdateHandler : IRequestHandler<CategoryChannelActivationUpdateCommand, Result<int>>
{
    private readonly IAppLogger<CategoryChannelActivationUpdateHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMediator _mediator;

    public CategoryChannelActivationUpdateHandler(
        IAppLogger<CategoryChannelActivationUpdateHandler> logger,
        ICategoryRepository categoryRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<int>> Handle(CategoryChannelActivationUpdateCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<int>();

        if (request.Changes.Count == 0)
        {
            result.Succeeded = true;
            result.Status = ResultStatus.Ok;
            result.Data = 0;
            return result;
        }

        // Re-apply the tree-consistency rule server-side (the client already expands, but the
        // server cannot trust that): activating a cell activates its ancestors, deactivating
        // deactivates its descendants.
        var parentByCategoryId = (await _categoryRepository.Entities
                .Select(c => new { c.Id, c.ParentCategoryId })
                .ToListAsync(cancellationToken))
            .ToDictionary(c => c.Id, c => c.ParentCategoryId);

        var expandedChanges = CategoryActivationRules.Expand(request.Changes, parentByCategoryId);

        var affectedRows = await _categoryRepository.ApplyChannelActivationAsync(expandedChanges, cancellationToken);

        // Primary export trigger per flipped cell: active rows are (re-)exported, inactive rows
        // deleted remotely. The persistence interceptor is only the safety net.
        foreach (var row in affectedRows)
        {
            await _mediator.Publish(
                new CategorySalesChannelChangedNotification(row.Id, row.CategoryId, row.SalesChannelId, row.TenantId),
                cancellationToken);
        }

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = affectedRows.Count;

        _logger.LogInformation("Applied {Count} category channel activation changes", affectedRows.Count);

        return result;
    }
}
