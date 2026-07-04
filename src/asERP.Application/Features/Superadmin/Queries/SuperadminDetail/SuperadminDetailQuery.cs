using asERP.Domain.Dtos.Superadmin;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Superadmin.Queries.SuperadminDetail;

public class SuperadminDetailQuery : IRequest<Result<SuperadminTenantDetailDto>>
{
    public Guid Id { get; set; }

    public SuperadminDetailQuery(Guid id)
    {
        Id = id;
    }
}