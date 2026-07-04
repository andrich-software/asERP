using asERP.Application.Mediator;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;

namespace asERP.Application.Features.ProductImage.Commands.ProductImageUpload;

public class ProductImageUploadCommand : IRequest<Result<ProductImageDto>>
{
    public Guid ProductId { get; set; }
    public IFormFile File { get; set; } = null!;
}
