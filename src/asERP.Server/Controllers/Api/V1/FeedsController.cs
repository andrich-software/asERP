using Asp.Versioning;
using asERP.Application.Features.Feed.Commands.FeedCreate;
using asERP.Application.Features.Feed.Commands.FeedDelete;
using asERP.Application.Features.Feed.Commands.FeedProductSelectionUpdate;
using asERP.Application.Features.Feed.Commands.FeedUpdate;
using asERP.Application.Features.Feed.Queries.FeedDetail;
using asERP.Application.Features.Feed.Queries.FeedList;
using asERP.Application.Features.Feed.Queries.FeedLogList;
using asERP.Application.Features.Feed.Queries.FeedProductSelectionList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class FeedsController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/feeds
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<FeedListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "DateCreated Descending";
        }

        var response = await mediator.Send(new FeedListQuery(pageNumber, pageSize, searchString, salesBy));
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: api/v1/feeds/{id}
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FeedDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new FeedDetailQuery { Id = id });
        if (response.Succeeded && response.Data is not null)
        {
            response.Data.PublicUrl = $"{Request.Scheme}://{Request.Host}/feed/{id}";
        }

        return StatusCode((int)response.StatusCode, response);
    }

    // POST: api/v1/feeds
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create(FeedCreateCommand command)
    {
        var response = await mediator.Send(command);
        return StatusCode((int)response.StatusCode, response);
    }

    // PUT: api/v1/feeds/{id}
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(Guid id, FeedUpdateCommand command)
    {
        if (command.Id != Guid.Empty && command.Id != id)
        {
            return BadRequest(new Result<Guid>
            {
                Succeeded = false,
                StatusCode = ResultStatusCode.BadRequest,
                Messages = { "ID in URL does not match ID in request body" }
            });
        }

        command.Id = id;
        var response = await mediator.Send(command);
        return StatusCode((int)response.StatusCode, response);
    }

    // DELETE: api/v1/feeds/{id}
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var response = await mediator.Send(new FeedDeleteCommand { Id = id });
        return response.ToActionResult();
    }

    // GET: api/v1/feeds/{id}/logs
    [HttpGet("{id:guid}/logs")]
    public async Task<ActionResult<PaginatedResult<FeedLogDto>>> GetLogs(Guid id, int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        var response = await mediator.Send(new FeedLogListQuery(id, pageNumber, pageSize, searchString, salesBy));
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: api/v1/feeds/{id}/products
    [HttpGet("{id:guid}/products")]
    public async Task<ActionResult<PaginatedResult<FeedProductSelectionDto>>> GetProducts(Guid id, int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        var response = await mediator.Send(new FeedProductSelectionListQuery(id, pageNumber, pageSize, searchString, salesBy));
        return StatusCode((int)response.StatusCode, response);
    }

    // PUT: api/v1/feeds/{id}/products
    [HttpPut("{id:guid}/products")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateProducts(Guid id, FeedProductSelectionUpdateDto dto)
    {
        var response = await mediator.Send(new FeedProductSelectionUpdateCommand
        {
            FeedId = id,
            Changes = dto.Changes
        });

        return StatusCode((int)response.StatusCode, response);
    }
}
