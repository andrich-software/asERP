using asERP.Application.Mediator;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Product.Commands.ProductUpdate;

/// <summary>
/// Validated inside the handler, not by the mediator: the validator's "Product not found" rule
/// has to become a 404, which the pipeline's uniform 400 cannot express. Moving that rule out of
/// the validator is part of the semantic-error work (REFACTOR.md R5).
/// </summary>
public class ProductUpdateCommand : ProductInputDto, IRequest<Result<Guid>>, ISkipPipelineValidation
{
}
