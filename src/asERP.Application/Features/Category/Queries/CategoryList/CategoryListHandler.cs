using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Category.Queries.CategoryList;

public class CategoryListHandler : IRequestHandler<CategoryListQuery, Result<List<CategoryListDto>>>
{
    private readonly IAppLogger<CategoryListHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryListHandler(
        IAppLogger<CategoryListHandler> logger,
        ICategoryRepository categoryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<Result<List<CategoryListDto>>> Handle(CategoryListQuery request, CancellationToken cancellationToken)
    {
        var result = new Result<List<CategoryListDto>>();

        result.Data = await _categoryRepository.Entities
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Name)
            .Select(c => new CategoryListDto
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
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
            .ToListAsync(cancellationToken);

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;

        return result;
    }
}
