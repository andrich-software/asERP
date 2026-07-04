using Asp.Versioning;
using asERP.Application.Features.WebAnalytics.Queries.WebSessionsSummary;
using asERP.Application.Features.WebAnalytics.Queries.WebTopProducts;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.WebAnalytics;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

/// <summary>
/// Authenticated dashboard reads for the "Web-Statistiken" tab. Tenant isolation is enforced inside the
/// query service (ClickHouse has no EF query filter), so these endpoints only forward the channel filter.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class WebStatisticsController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/WebStatistics/Sessions
    [HttpGet("Sessions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Result<WebSessionsSummaryDto>>> Sessions([FromQuery] Guid salesChannelId)
    {
        var result = await mediator.Send(new WebSessionsSummaryQuery(salesChannelId));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/WebStatistics/TopProducts
    [HttpGet("TopProducts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Result<WebTopProductsDto>>> TopProducts(
        [FromQuery] Guid salesChannelId,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate,
        [FromQuery] int count = 10)
    {
        var result = await mediator.Send(new WebTopProductsQuery(salesChannelId, startDate, endDate, count));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }
}
