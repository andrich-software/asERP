using asERP.Application.Features.Category.Commands.CategoryChannelActivationUpdate;
using asERP.Application.Features.Category.Commands.CategoryCreate;
using asERP.Application.Features.Category.Commands.CategoryDelete;
using asERP.Application.Features.Category.Commands.CategoryUpdate;
using asERP.Application.Features.Category.Queries.CategoryDetail;
using asERP.Application.Features.Category.Queries.CategoryList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Category;
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
public class CategoriesController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<CategoriesController>
    // Deliberately unpaginated: the tree view always needs the full set and per-tenant category
    // counts are small. Ordering/indentation is derived client-side.
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Result<List<CategoryListDto>>>> GetAll()
    {
        var response = await mediator.Send(new CategoryListQuery());
        return response.ToActionResult();
    }

    // GET api/v1/<CategoriesController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new CategoryDetailQuery(id));
        return response.ToActionResult();
    }

    // POST: api/v1/<CategoriesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create(CategoryCreateCommand categoryCreateCommand)
    {
        var response = await mediator.Send(categoryCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<CategoriesController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(Guid id, CategoryUpdateCommand categoryUpdateCommand)
    {
        categoryUpdateCommand.Id = id;
        var response = await mediator.Send(categoryUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<CategoriesController>/5
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new CategoryDeleteCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    // PUT: api/v1/<CategoriesController>/channels
    // Batch of per-channel activation changes from the category matrix (delta-tracked client-side).
    [HttpPut("channels")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Result<int>>> UpdateChannelActivations(CategoryChannelActivationUpdateDto dto)
    {
        var response = await mediator.Send(new CategoryChannelActivationUpdateCommand
        {
            Changes = dto.Changes
        });

        return response.ToActionResult();
    }
}
