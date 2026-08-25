using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Commands.CategoryDelete;

public class CategoryDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
