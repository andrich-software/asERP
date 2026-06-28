using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Product.Commands.ProductVariantGenerate;

/// <summary>
/// Command for generating variant products from the cartesian product of selected
/// attribute values per parent axis. Existing combinations are skipped (idempotent).
/// </summary>
public class ProductVariantGenerateCommand : ProductVariantGenerateDto, IRequest<Result<List<Guid>>>
{
}
