using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesReturnableItems;

public class SalesReturnableItemsQuery : IRequest<Result<List<ReturnableSalesItemDto>>>
{
    public Guid Id { get; set; }
}
