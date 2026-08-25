using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Commands.CategoryDelete;

public class CategoryDeleteHandler : IRequestHandler<CategoryDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<CategoryDeleteHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMediator _mediator;

    public CategoryDeleteHandler(
        IAppLogger<CategoryDeleteHandler> logger,
        ICategoryRepository categoryRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting category with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        var validator = new CategoryDeleteValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in delete request for {0}: {1}",
                nameof(CategoryDeleteCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(request.Id, asNoTracking: true);
            if (existingCategory == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Category with ID {request.Id} not found");
                return result;
            }

            // Snapshot the channel links before they are cascaded away — the remote deletes need
            // the channel-side ids after the rows are gone.
            var channelLinks = await _categoryRepository.GetChannelLinksAsync(existingCategory.Id);
            var deleteSnapshots = channelLinks
                .Select(l => new CategoryDeleteSnapshot(l.SalesChannelId, l.Id, l.RemoteCategoryId, l.IsActive))
                .ToList();

            await _categoryRepository.DeleteWithDependentsAsync(existingCategory.Id);

            await _mediator.Publish(
                new CategoryChangedNotification(
                    existingCategory.Id, existingCategory.TenantId, CategoryChangeKind.Deleted, deleteSnapshots),
                cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = existingCategory.Id;

            _logger.LogInformation("Successfully deleted category with ID: {Id}", existingCategory.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while deleting the category.",
                "Error deleting category {Id}.", request.Id);
        }

        return result;
    }
}
