using maERP.Application.Mediator;
using maERP.Domain.Wrapper;

namespace maERP.Application.Features.ProductImage.Commands.ProductImageReorder;

public class ProductImageReorderCommand : IRequest<Result<Guid>>
{
    public Guid ProductId { get; set; }

    /// <summary>The product's image ids in the desired order (index 0 becomes the primary image).</summary>
    public List<Guid> OrderedImageIds { get; set; } = new();
}
