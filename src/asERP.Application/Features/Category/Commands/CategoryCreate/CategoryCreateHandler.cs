using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Services;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Commands.CategoryCreate;

public class CategoryCreateHandler : IRequestHandler<CategoryCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<CategoryCreateHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryCreateHandler(
        IAppLogger<CategoryCreateHandler> logger,
        ICategoryRepository categoryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<Result<Guid>> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new category with name: {Name}", request.Name);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new CategoryCreateValidator(_categoryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(CategoryCreateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Manual mapping to domain entity
            var categoryToCreate = new Domain.Entities.Category
            {
                Name = request.Name,
                Slug = ResolveSlug(request.Slug, request.Name),
                Description = request.Description,
                ParentCategoryId = request.ParentCategoryId,
                SortOrder = request.SortOrder
            };

            await _categoryRepository.CreateAsync(categoryToCreate);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = categoryToCreate.Id;

            _logger.LogInformation("Successfully created category with ID: {Id}", categoryToCreate.Id);
        }
        catch (Exception ex)
        {
            // Never leak the raw exception text.
            result.FromException(_logger, ex,
                "An error occurred while creating the category.",
                "Error creating category.");
        }

        return result;
    }

    internal static string ResolveSlug(string slug, string name)
    {
        var resolved = string.IsNullOrWhiteSpace(slug)
            ? CategorySlugGenerator.Generate(name)
            : slug.Trim();

        return string.IsNullOrEmpty(resolved) ? "category" : resolved;
    }
}
