using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Wrapper;
using Microsoft.AspNetCore.Http;

namespace asToolkit.Application.Features.ProductImage.Commands.ProductImageUpload;

public class ProductImageUploadCommand : IRequest<Result<ProductImageDto>>
{
    public Guid ProductId { get; set; }
    public IFormFile File { get; set; } = null!;
}
