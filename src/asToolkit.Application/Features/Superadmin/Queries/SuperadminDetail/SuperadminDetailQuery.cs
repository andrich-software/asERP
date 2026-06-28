using asToolkit.Domain.Dtos.Superadmin;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Superadmin.Queries.SuperadminDetail;

public class SuperadminDetailQuery : IRequest<Result<SuperadminTenantDetailDto>>
{
    public Guid Id { get; set; }

    public SuperadminDetailQuery(Guid id)
    {
        Id = id;
    }
}