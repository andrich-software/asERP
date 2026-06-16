using maERP.Application.Mediator;
using maERP.Domain.Dtos.Product;
using maERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;

namespace maERP.Application.Features.ProductImage.Commands.ProductImageUpload;

public class ProductImageUploadCommand : IRequest<Result<ProductImageDto>>
{
    public Guid ProductId { get; set; }
    public IFormFile File { get; set; } = null!;
}
