using asERP.Application.Contracts.Persistence;
using asERP.Domain.Validators;
using FluentValidation;

namespace asERP.Application.Features.Category.Commands.CategoryCreate;

public class CategoryCreateValidator : CategoryBaseValidator<CategoryCreateCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryCreateValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(q => q)
            .MustAsync(IsUniqueAsync).WithMessage("A category with the same name already exists under this parent.");

        RuleFor(q => q.ParentCategoryId)
            .MustAsync(ParentExistsAsync).WithMessage("The parent category does not exist.")
            .When(q => q.ParentCategoryId.HasValue);
    }

    private async Task<bool> IsUniqueAsync(CategoryCreateCommand command, CancellationToken cancellationToken)
    {
        var categoryToCreate = new Domain.Entities.Category
        {
            Name = command.Name,
            ParentCategoryId = command.ParentCategoryId
        };

        return await _categoryRepository.IsUniqueAsync(categoryToCreate);
    }

    private async Task<bool> ParentExistsAsync(Guid? parentCategoryId, CancellationToken cancellationToken)
    {
        return parentCategoryId is null || await _categoryRepository.ExistsAsync(parentCategoryId.Value);
    }
}
