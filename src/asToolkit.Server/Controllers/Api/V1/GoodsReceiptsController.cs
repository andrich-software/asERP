using Asp.Versioning;
using asToolkit.Application.Features.GoodsReceipt.Commands.GoodsReceiptCreate;
using asToolkit.Application.Features.GoodsReceipt.Queries.GoodsReceiptDetail;
using asToolkit.Application.Features.GoodsReceipt.Queries.GoodsReceiptList;
using asToolkit.Domain.Dtos.GoodsReceipt;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class GoodsReceiptsController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/goodsreceipts
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<GoodsReceiptListDto>>> GetAll(
        int pageNumber = 0,
        int pageSize = 50,
        string searchTerm = "",
        string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "ReceiptDate Descending";
        }

        var response = await mediator.Send(new GoodsReceiptListQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            SalesBy = salesBy
        });

        return StatusCode((int)response.StatusCode, response);
    }

    // GET: api/v1/goodsreceipts/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GoodsReceiptDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new GoodsReceiptDetailQuery { Id = id });
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: api/v1/goodsreceipts
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create(GoodsReceiptCreateCommand goodsReceiptCreateCommand)
    {
        var response = await mediator.Send(goodsReceiptCreateCommand);
        return StatusCode((int)response.StatusCode, response);
    }
}