using asERP.Application.Contracts.Persistence;
using FluentValidation;

namespace asERP.Application.Features.Category.Commands.CategoryDelete;

public class CategoryDeleteValidator : AbstractValidator<CategoryDeleteCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryDeleteValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(p => p.Id)
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.")
            .MustAsync(HasNoChildrenAsync).WithMessage("The category has child categories. Delete or move them first.");
    }

    private async Task<bool> HasNoChildrenAsync(Guid id, CancellationToken cancellationToken)
    {
        return !await _categoryRepository.HasChildrenAsync(id);
    }
}
