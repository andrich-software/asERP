using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Features.Category.Commands.CategoryCreate;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Commands.CategoryUpdate;

public class CategoryUpdateHandler : IRequestHandler<CategoryUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<CategoryUpdateHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMediator _mediator;

    public CategoryUpdateHandler(
        IAppLogger<CategoryUpdateHandler> logger,
        ICategoryRepository categoryRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating category with ID: {Id} and name: {Name}", request.Id, request.Name);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new CategoryUpdateValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(CategoryUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(request.Id);
            if (existingCategory == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Category with ID {request.Id} not found");
                return result;
            }

            existingCategory.Name = request.Name;
            existingCategory.Slug = CategoryCreateHandler.ResolveSlug(request.Slug, request.Name);
            existingCategory.Description = request.Description;
            existingCategory.ParentCategoryId = request.ParentCategoryId;
            existingCategory.SortOrder = request.SortOrder;

            await _categoryRepository.UpdateAsync(existingCategory);

            // Primary export trigger: re-push the category to every channel it is active on.
            // (The persistence interceptor is only the safety net.)
            await _mediator.Publish(
                new CategoryChangedNotification(existingCategory.Id, existingCategory.TenantId, CategoryChangeKind.Updated),
                cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = existingCategory.Id;

            _logger.LogInformation("Successfully updated category with ID: {Id}", existingCategory.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while updating the category.",
                "Error updating category {Id}.", request.Id);
        }

        return result;
    }
}
