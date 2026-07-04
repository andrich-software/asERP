using Asp.Versioning;
using asERP.Application.Features.Statistic.Queries.CustomersToday;
using asERP.Application.Features.Statistic.Queries.SalessLatest;
using asERP.Application.Features.Statistic.Queries.SalessToday;
using asERP.Application.Features.Statistic.Queries.ProductsBestSelling;
using asERP.Application.Features.Statistic.Queries.ProductsToday;
using asERP.Application.Features.Statistic.Queries.RevenueChart;
using asERP.Application.Features.Statistic.Queries.SalesToday;
using asERP.Application.Features.Statistic.Queries.StatisticSales;
using asERP.Application.Features.Statistic.Queries.StatisticSalesCustomerChart;
using asERP.Application.Features.Statistic.Queries.StatisticProduct;
using asERP.Application.Features.Statistic.Queries.StatisticSalesOverview;
using asERP.Application.Features.Statistic.Queries.StatisticMostSellingProducts;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class StatisticsController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<StatisticsController>/SalesToday
    [HttpGet("SalesToday")]
    public async Task<ActionResult<Result<SalesTodayDto>>> SalesToday([FromQuery] Guid? salesChannelId = null, [FromQuery] int? hours = null)
    {
        var result = await mediator.Send(new SalesTodayQuery(salesChannelId, hours));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>/SalessToday
    [HttpGet("SalessToday")]
    public async Task<ActionResult<Result<SalessTodayDto>>> SalessToday([FromQuery] Guid? salesChannelId = null, [FromQuery] int? hours = null)
    {
        var result = await mediator.Send(new SalessTodayQuery(salesChannelId, hours));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>/CustomersToday
    [HttpGet("CustomersToday")]
    public async Task<ActionResult<Result<CustomersTodayDto>>> CustomersToday([FromQuery] int? hours = null)
    {
        var result = await mediator.Send(new CustomersTodayQuery(hours));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>/ProductsToday
    [HttpGet("ProductsToday")]
    public async Task<ActionResult<Result<ProductsTodayDto>>> ProductsToday()
    {
        var result = await mediator.Send(new ProductsTodayQuery());

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>/SalessLatest
    [HttpGet("SalessLatest")]
    public async Task<ActionResult<Result<SalessLatestDto>>> SalessLatest([FromQuery] int count = 5, [FromQuery] Guid? salesChannelId = null)
    {
        var result = await mediator.Send(new SalessLatestQuery(count, salesChannelId));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>/ProductsBestSelling
    [HttpGet("ProductsBestSelling")]
    public async Task<ActionResult<Result<ProductsBestSellingDto>>> ProductsBestSelling([FromQuery] int count = 5, [FromQuery] int? hours = null)
    {
        var result = await mediator.Send(new ProductsBestSellingQuery(count, hours));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>/RevenueChart
    [HttpGet("RevenueChart")]
    public async Task<ActionResult<Result<RevenueChartDto>>> RevenueChart(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate,
        [FromQuery] Guid? salesChannelId = null)
    {
        var result = await mediator.Send(new RevenueChartQuery(startDate, endDate, salesChannelId));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>
    [HttpGet("SalesStatistic")]
    public async Task<ActionResult<Result<StatisticSalesDto>>> SalesStatistic()
    {
        var result = await mediator.Send(new StatisticSalesQuery());

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>
    [HttpGet("ProductStatistic")]
    public async Task<ActionResult<Result<StatisticProductDto>>> ProductStatistic()
    {
        var result = await mediator.Send(new StatisticProductQuery());

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>
    [HttpGet("SalesCustomerChart")]
    public async Task<ActionResult<Result<StatisticSalesCustomerChartResponse>>> SalesCustomerChart()
    {
        var result = await mediator.Send(new StatisticSalesCustomerChartQuery());

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>
    [HttpGet("OrderStatistic")]
    public async Task<ActionResult<Result<StatisticSalesOverviewDto>>> OrderStatistic()
    {
        var result = await mediator.Send(new StatisticSalesOverviewQuery());

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>
    [HttpGet("MostSellingProducts")]
    public async Task<ActionResult<Result<StatisticMostSellingProductsDto>>> MostSellingProducts()
    {
        var result = await mediator.Send(new StatisticMostSellingProductsQuery());

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }
}