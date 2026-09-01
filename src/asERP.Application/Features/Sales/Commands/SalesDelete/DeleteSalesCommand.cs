using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Commands.SalesDelete;

/// <summary>
/// Not validated by the mediator: `SalesController.Delete` discards the result and always answers
/// 204, so the validator's existence rule has never reached a client. Letting the pipeline throw
/// would turn this deliberately idempotent DELETE into a 400.
/// </summary>
public class DeleteSalesCommand : IRequest<Result<Guid>>, ISkipPipelineValidation
{
    public Guid Id { get; set; }
}
