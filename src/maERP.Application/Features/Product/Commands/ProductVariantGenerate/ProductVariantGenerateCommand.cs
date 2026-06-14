using maERP.Domain.Dtos.Product;
using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.Product.Commands.ProductVariantGenerate;

/// <summary>
/// Command for generating variant products from the cartesian product of selected
/// attribute values per parent axis. Existing combinations are skipped (idempotent).
/// </summary>
public class ProductVariantGenerateCommand : ProductVariantGenerateDto, IRequest<Result<List<Guid>>>
{
}
