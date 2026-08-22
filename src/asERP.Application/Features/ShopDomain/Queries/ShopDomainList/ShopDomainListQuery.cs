using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShopDomain;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShopDomain.Queries.ShopDomainList;

/// <summary>Lists the host bindings of one sales channel (a handful of rows — not paginated).</summary>
public record ShopDomainListQuery(Guid SalesChannelId) : IRequest<Result<List<ShopDomainListDto>>>;
