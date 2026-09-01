using asERP.Application.Features.GoodsReceipt.Commands.GoodsReceiptCreate;
using asERP.Application.Features.GoodsReceipt.Queries.GoodsReceiptDetail;
using asERP.Application.Features.GoodsReceipt.Queries.GoodsReceiptList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.GoodsReceipt;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

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
        string sortBy = "")
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            sortBy = "ReceiptDate Descending";
        }

        var response = await mediator.Send(new GoodsReceiptListQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchTerm = searchTerm,
            SortBy = sortBy
        });

        return response.ToActionResult();
    }

    // GET: api/v1/goodsreceipts/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GoodsReceiptDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new GoodsReceiptDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // POST: api/v1/goodsreceipts
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create(GoodsReceiptCreateCommand goodsReceiptCreateCommand)
    {
        var response = await mediator.Send(goodsReceiptCreateCommand);
        return response.ToActionResult();
    }
}
