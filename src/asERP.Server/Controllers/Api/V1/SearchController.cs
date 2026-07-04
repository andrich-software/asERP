using Asp.Versioning;
using asERP.Application.Features.Search.Queries.GlobalSearch;
using asERP.Domain.Dtos.Search;
using asERP.Application.Mediator;
using asERP.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class SearchController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/search?searchString=abc&limit=5
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Domain.Wrapper.Result<GlobalSearchResultDto>>> Search(string searchString = "", int limit = 5)
    {
        var response = await mediator.Send(new GlobalSearchQuery { SearchString = searchString, Limit = limit });
        return response.ToActionResult();
    }
}
