using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ProductImage.Queries.ProductImageContent;

public class ProductImageContentQuery : IRequest<Result<ProductImageFile>>
{
    public Guid ProductId { get; set; }
    public Guid ImageId { get; set; }

    /// <summary>When true, returns the thumbnail instead of the original.</summary>
    public bool Thumbnail { get; set; }
}

/// <summary>
/// A streamable image file. <see cref="Content"/> is an open stream the caller is responsible
/// for disposing (the controller streams it to the response).
/// </summary>
public record ProductImageFile(Stream Content, string ContentType, string FileName);
