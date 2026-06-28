using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Enums;

namespace asToolkit.Application.Features.Product.Shared;

/// <summary>
/// Cross-entity validation rules for variant products that need loaded aggregates
/// (parent axes, sibling variants) and therefore live outside the FluentValidation validators.
/// All methods return null when valid, otherwise a user-facing error message.
/// </summary>
public static class ProductVariantRules
{
    /// <summary>
    /// Validates a variant's parent reference and option set: the parent must be a variant parent
    /// with defined axes, the options must cover each axis exactly once and the combination must
    /// be unique among the siblings. Returns the loaded parent for further use.
    /// </summary>
    public static async Task<(string? Error, Domain.Entities.Product? Parent)> ValidateVariantAsync(
        ProductInputDto request,
        Guid? existingProductId,
        IProductRepository productRepository)
    {
        var parent = await productRepository.GetWithDetailsAsync(request.ParentProductId!.Value);

        if (parent == null)
        {
            return ("Parent product not found.", null);
        }

        if (parent.ProductType != ProductType.VariantParent)
        {
            return ("Parent product is not a variant parent.", null);
        }

        var axes = parent.VariantAxes.OrderBy(a => a.SortOrder).ToList();
        if (axes.Count == 0)
        {
            return ("Parent product has no variant axes defined.", null);
        }

        var optionIds = request.VariantOptionValueIds.Distinct().ToList();

        // Map every selectable value of the parent's axes to its attribute
        var valueToAttribute = new Dictionary<Guid, Guid>();
        foreach (var axis in axes)
        {
            foreach (var value in axis.ProductAttribute?.Values ?? [])
            {
                valueToAttribute[value.Id] = axis.ProductAttributeId;
            }
        }

        foreach (var optionId in optionIds)
        {
            if (!valueToAttribute.ContainsKey(optionId))
            {
                return ($"Option value {optionId} does not belong to any axis of the parent product.", null);
            }
        }

        var perAxis = optionIds.GroupBy(id => valueToAttribute[id]).ToList();
        if (perAxis.Any(g => g.Count() > 1))
        {
            return ("A variant may carry only one value per axis.", null);
        }

        if (perAxis.Count != axes.Count)
        {
            return ("A variant must define exactly one value per parent axis.", null);
        }

        var optionSet = optionIds.ToHashSet();
        foreach (var sibling in parent.Variants.Where(v => v.Id != existingProductId))
        {
            var siblingSet = sibling.VariantOptions.Select(o => o.ProductAttributeValueId).ToHashSet();
            if (siblingSet.SetEquals(optionSet))
            {
                return ($"A variant with the same option combination already exists (SKU: {sibling.Sku}).", null);
            }
        }

        return (null, parent);
    }

    /// <summary>
    /// Validates the axis attribute selection of a variant parent.
    /// </summary>
    public static async Task<string?> ValidateParentAxesAsync(
        ProductInputDto request,
        IProductAttributeRepository productAttributeRepository)
    {
        var axisIds = request.VariantAxisAttributeIds;

        if (axisIds.Distinct().Count() != axisIds.Count)
        {
            return "Variant axes must be unique.";
        }

        foreach (var attributeId in axisIds)
        {
            if (!await productAttributeRepository.ExistsAsync(attributeId))
            {
                return $"Variant axis attribute {attributeId} does not exist.";
            }
        }

        return null;
    }

    /// <summary>
    /// Validates a product type change on update. Only Standard ↔ VariantParent transitions
    /// are allowed, and only while the parent has no variants. Variants keep their parent.
    /// </summary>
    public static string? ValidateTypeTransition(
        Domain.Entities.Product existing,
        ProductInputDto request,
        int variantCount)
    {
        if (existing.ProductType == request.ProductType)
        {
            if (existing.ProductType == ProductType.Variant && existing.ParentProductId != request.ParentProductId)
            {
                return "The parent product of a variant cannot be changed.";
            }

            return null;
        }

        if (existing.ProductType == ProductType.Variant || request.ProductType == ProductType.Variant)
        {
            return "A product cannot be converted to or from a variant.";
        }

        if (existing.ProductType == ProductType.VariantParent && variantCount > 0)
        {
            return "A variant parent with existing variants cannot be converted to another product type.";
        }

        return null;
    }
}
