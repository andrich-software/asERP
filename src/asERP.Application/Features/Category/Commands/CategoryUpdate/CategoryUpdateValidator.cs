using asERP.Application.Contracts.Persistence;
using asERP.Domain.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Category.Commands.CategoryUpdate;

public class CategoryUpdateValidator : CategoryBaseValidator<CategoryUpdateCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryUpdateValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(p => p.Id)
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.")
            .MustAsync(CategoryExistsAsync).WithMessage("The category does not exist.");

        RuleFor(q => q)
            .MustAsync(IsUniqueAsync).WithMessage("A category with the same name already exists under this parent.");

        RuleFor(q => q.ParentCategoryId)
            .MustAsync(ParentExistsAsync).WithMessage("The parent category does not exist.")
            .MustAsync(NotCreateCycleAsync).WithMessage("A category cannot be its own ancestor.")
            .When(q => q.ParentCategoryId.HasValue);
    }

    private async Task<bool> CategoryExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _categoryRepository.ExistsAsync(id);
    }

    private async Task<bool> IsUniqueAsync(CategoryUpdateCommand command, CancellationToken cancellationToken)
    {
        var categoryToUpdate = new Domain.Entities.Category
        {
            Name = command.Name,
            ParentCategoryId = command.ParentCategoryId
        };

        return await _categoryRepository.IsUniqueAsync(categoryToUpdate, command.Id);
    }

    private async Task<bool> ParentExistsAsync(CategoryUpdateCommand command, Guid? parentCategoryId, CancellationToken cancellationToken)
    {
        return parentCategoryId is null || await _categoryRepository.ExistsAsync(parentCategoryId.Value);
    }

    /// <summary>
    /// Walks the proposed parent's ancestor chain; if it passes through the category itself the
    /// reparent would create a cycle. The visited guard terminates even on already-corrupt data.
    /// </summary>
    private async Task<bool> NotCreateCycleAsync(CategoryUpdateCommand command, Guid? parentCategoryId, CancellationToken cancellationToken)
    {
        if (parentCategoryId is null)
        {
            return true;
        }

        if (parentCategoryId == command.Id)
        {
            return false;
        }

        var parents = await _categoryRepository.Entities
            .Select(c => new { c.Id, c.ParentCategoryId })
            .ToListAsync(cancellationToken);
        var parentById = parents.ToDictionary(c => c.Id, c => c.ParentCategoryId);

        var visited = new HashSet<Guid>();
        var current = parentCategoryId;
        while (current.HasValue && visited.Add(current.Value))
        {
            if (current.Value == command.Id)
            {
                return false;
            }

            current = parentById.GetValueOrDefault(current.Value);
        }

        return true;
    }
}
