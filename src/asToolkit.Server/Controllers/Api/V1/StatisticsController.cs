using Asp.Versioning;
using asToolkit.Application.Features.Statistic.Queries.CustomersToday;
using asToolkit.Application.Features.Statistic.Queries.SalessLatest;
using asToolkit.Application.Features.Statistic.Queries.SalessToday;
using asToolkit.Application.Features.Statistic.Queries.ProductsBestSelling;
using asToolkit.Application.Features.Statistic.Queries.ProductsToday;
using asToolkit.Application.Features.Statistic.Queries.RevenueChart;
using asToolkit.Application.Features.Statistic.Queries.SalesToday;
using asToolkit.Application.Features.Statistic.Queries.StatisticSales;
using asToolkit.Application.Features.Statistic.Queries.StatisticSalesCustomerChart;
using asToolkit.Application.Features.Statistic.Queries.StatisticProduct;
using asToolkit.Application.Features.Statistic.Queries.StatisticSalesOverview;
using asToolkit.Application.Features.Statistic.Queries.StatisticMostSellingProducts;
using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class StatisticsController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<StatisticsController>/SalesToday
    [HttpGet("SalesToday")]
    public async Task<ActionResult<Result<SalesTodayDto>>> SalesToday([FromQuery] Guid? salesChannelId = null)
    {
        var result = await mediator.Send(new SalesTodayQuery(salesChannelId));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>/SalessToday
    [HttpGet("SalessToday")]
    public async Task<ActionResult<Result<SalessTodayDto>>> SalessToday([FromQuery] Guid? salesChannelId = null)
    {
        var result = await mediator.Send(new SalessTodayQuery(salesChannelId));

        if (!result.Succeeded)
            return StatusCode((int)result.StatusCode, result);

        return Ok(result);
    }

    // GET: api/v1/<StatisticsController>/CustomersToday
    [HttpGet("CustomersToday")]
    public async Task<ActionResult<Result<CustomersTodayDto>>> CustomersToday()
    {
        var result = await mediator.Send(new CustomersTodayQuery());

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
    public async Task<ActionResult<Result<ProductsBestSellingDto>>> ProductsBestSelling([FromQuery] int count = 5)
    {
        var result = await mediator.Send(new ProductsBestSellingQuery(count));

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