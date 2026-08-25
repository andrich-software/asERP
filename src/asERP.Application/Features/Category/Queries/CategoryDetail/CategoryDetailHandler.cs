using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Category.Queries.CategoryDetail;

public class CategoryDetailHandler : IRequestHandler<CategoryDetailQuery, Result<CategoryDetailDto>>
{
    private readonly IAppLogger<CategoryDetailHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryDetailHandler(
        IAppLogger<CategoryDetailHandler> logger,
        ICategoryRepository categoryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<Result<CategoryDetailDto>> Handle(CategoryDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving category details for ID: {Id}", request.Id);

        var result = new Result<CategoryDetailDto>();

        try
        {
            var data = await _categoryRepository.Entities
                .Where(c => c.Id == request.Id)
                .Select(c => new CategoryDetailDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    Description = c.Description,
                    ParentCategoryId = c.ParentCategoryId,
                    SortOrder = c.SortOrder,
                    ProductCount = c.ProductCategories.Count,
                    Channels = c.SalesChannels
                        .Select(l => new CategoryChannelStateDto
                        {
                            SalesChannelId = l.SalesChannelId,
                            IsActive = l.IsActive
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (data == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Category with ID {request.Id} not found");
                return result;
            }

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = data;
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while retrieving the category.",
                "Error retrieving category {Id}.", request.Id);
        }

        return result;
    }
}
