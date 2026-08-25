using asERP.Application.Mediator;
using asERP.Domain.Dtos.Superadmin;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Superadmin.Queries.SuperadminDetail;

public class SuperadminDetailQuery : IRequest<Result<SuperadminTenantDetailDto>>
{
    public Guid Id { get; set; }

    public SuperadminDetailQuery(Guid id)
    {
        Id = id;
    }
}
