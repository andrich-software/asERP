using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ProductImage.Commands.ProductImageReorder;

public class ProductImageReorderCommand : IRequest<Result<Guid>>
{
    public Guid ProductId { get; set; }

    /// <summary>The product's image ids in the desired order (index 0 becomes the primary image).</summary>
    public List<Guid> OrderedImageIds { get; set; } = new();
}
