using Asp.Versioning;
using asERP.Application.Features.ProductAttribute.Commands.ProductAttributeCreate;
using asERP.Application.Features.ProductAttribute.Commands.ProductAttributeDelete;
using asERP.Application.Features.ProductAttribute.Commands.ProductAttributeUpdate;
using asERP.Application.Features.ProductAttribute.Queries.ProductAttributeDetail;
using asERP.Application.Features.ProductAttribute.Queries.ProductAttributeList;
using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using asERP.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class ProductAttributesController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<ProductAttributesController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedResult<ProductAttributeListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "SortOrder Ascending";
        }

        var response = await mediator.Send(new ProductAttributeListQuery(pageNumber, pageSize, searchString, salesBy));
        return response.ToActionResult();
    }

    // GET api/v1/<ProductAttributesController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductAttributeDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new ProductAttributeDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // POST: api/v1/<ProductAttributesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create(ProductAttributeCreateCommand productAttributeCreateCommand)
    {
        var response = await mediator.Send(productAttributeCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<ProductAttributesController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(Guid id, ProductAttributeUpdateCommand productAttributeUpdateCommand)
    {
        productAttributeUpdateCommand.Id = id;
        var response = await mediator.Send(productAttributeUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<ProductAttributesController>/5
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new ProductAttributeDeleteCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }
}
