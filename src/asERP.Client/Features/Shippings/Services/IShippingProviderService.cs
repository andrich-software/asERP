using asERP.Client.Core.Models;
using asERP.Domain.Dtos.ShippingProvider;

namespace asERP.Client.Features.Shippings.Services;

/// <summary>
/// Read access to the tenant's configured shipping providers. Only the list is needed on the client
/// so far — providers themselves are managed on the server side.
/// </summary>
public interface IShippingProviderService
{
    Task<PaginatedResponse<ShippingProviderListDto>> GetProvidersAsync(
        QueryParameters parameters,
        CancellationToken ct = default);
}
